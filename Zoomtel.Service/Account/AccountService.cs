using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity;
using Zoomtel.Entity.Account;
using Zoomtel.Entity.LoginLog;
using Zoomtel.Persist;
using Zoomtel.Persist.Account;
using Zoomtel.Persist.Account.Models;
using Zoomtel.Persist.LoginInfo;
using Zoomtel.Service.Account.ViewModels;
using Zoomtel.Service.Auth;
using Zoomtel.Service.LoginLog;
using Zoomtel.Utils.Helpers;

namespace Zoomtel.Service.Account
{
    public class AccountService 
    {

        private AccountRepository _accountRepository;
        private readonly LoginLogRepository _loginLogRepository;
        private readonly LoginLogService _loginLogService;

        private readonly AccountRoleRepository _accountRoleRepository;
        private readonly ILoginInfo _loginInfo;//这里主要获取IP 和浏览器信息
        private readonly IMapper _mapper;
        private JwtSettings _jwtSettings;

        public AccountService(IOptions<JwtSettings> _jwtSettingsAccesser, ILoginInfo loginInfo, LoginLogService loginLogService, LoginLogRepository loginLogRepository, AccountRepository accountRepository, AccountRoleRepository accountRoleRepository,IMapper mapper)
        {
            _jwtSettings = _jwtSettingsAccesser.Value;

            _loginLogService = loginLogService;
            _loginLogRepository = loginLogRepository;
            _accountRepository = accountRepository;
            _accountRoleRepository = accountRoleRepository;
            _loginInfo = loginInfo;
                _mapper = mapper;

        }

        public Task<IResultModel> Active(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResultModel<Guid>> Add(AccountAddModel model)
        {
            var result = new ResultModel<Guid>();

            var account = _mapper.Map<AccountEntity>(model);
            var exists = await Exists(account);
            if (!exists.Successful)
                return exists;

            //设置默认密码
            if (account.LoginPwd.IsNull())
            {
                account.LoginPwd =  "123456";
            }
            account.PassSalt = new StringHelper().GenerateRandom(8);
            account.LoginPwd =  Zoomtel.Utils.Helpers.Encrypt.DESEncrypt(account.LoginPwd, account.PassSalt);
            
            _accountRepository.BeginTrans();
            if (await _accountRepository.InsertAsync(account) > 0)
            {
                //插入角色绑定信息
                if (model.RoleList != null && model.RoleList.Count>0)
                {
                    var accountRoleList = model.RoleList.Select(m => new AccountRoleEntity { Uid = account.Uid, RoleId = m }).ToList();
                    if (await _accountRoleRepository.InsertAsync(accountRoleList)>0)
                    {

                        _accountRepository.Commit();
                        return result.Success(account.Uid);
                    }
                }
                else
                {
                    _accountRepository.Commit();
                    return result.Success(account.Uid);
                }
            }

            return result.Failed();
        }

        public async Task<IResultModel> Delete(Guid id, Guid deleter)
        {
            if (id.Equals(deleter))
            {
                return ResultModel.Failed("不能删除自己的账户");
            }
            int i=await _accountRepository.DeleteAsync(id);
            if (i > 0)
            {
                return ResultModel.Success();
            }
            else
            {
                return ResultModel.Failed();
            }
        }

        public Task<IResultModel> Edit(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountEntity> Get(Guid id)
        {
         return   _accountRepository.FindEntityAsync(id);
        }

        public async Task<IResultModel<QueryResultModel<AccountEntity>>> Query(AccountQueryModel model)
        {
            var result = new ResultModel<QueryResultModel<AccountEntity>>();

            var data = await _accountRepository.Query(model);

            foreach (var item in data.Rows)
            {
                var roles = await _accountRoleRepository.QueryRole(item.Uid);
                item.Roles = roles.Select(r => new OptionResultModel { Label = r.RoleName, Value = r.Id }).ToList();
            }


            return result.Success(data);

        }

        public async Task<IResultModel> ResetPassword(Guid id)
        {
          
         if(await   _accountRepository.UpdatePassword(id, "123456"))
            {
                return ResultModel.Success();
            }
            else
            {
                return ResultModel.Failed();
            }
        }

        public async Task<IResultModel> Update(AccountUpdateModel model)
        {

            var user = _accountRepository.FindEntity(model.Uid);
            if (user == null)
                return ResultModel.Failed("账户不存在！");
            if (user.LoginName != model.LoginName)//改了用户名
            {
                if (await _accountRepository.ExistsLoginName(model.LoginName))
                    return ResultModel.Failed("用户名已存在");
            }
            if (user.Phone != model.Phone)//改了手机号码
            {
                if (await _accountRepository.ExistsPhone(model.Phone))
                    return ResultModel.Failed("手机号已存在");
            }
            var account = _mapper.Map(model, user);

            var exists = await Exists(account);
            if (!exists.Successful)
                return exists;

            _accountRepository.BeginTrans();
            
            
            int result=await    _accountRepository.UpdateAsync(account);
            if (result > 0)
            {
              result=  _accountRoleRepository.Delete(a => a.Uid == account.Uid);
                if (result > 0)
                {
                    //插入角色绑定信息
                    if (model.RoleList != null && model.RoleList.Count > 0)
                    {
                        var accountRoleList = model.RoleList.Select(m => new AccountRoleEntity { Uid = account.Uid, RoleId = m }).ToList();
                      await  _accountRoleRepository.InsertAsync(accountRoleList);
                    }
                   
                    _accountRepository.Commit();
                    return ResultModel.Success();

                }

            }
            
           return ResultModel.Failed();
        }

        public Task<IResultModel> UpdatePassword(UpdatePasswordModel model)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 判断账户是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task<IResultModel<Guid>> Exists(AccountEntity entity)
        {
            var result = new ResultModel<Guid>();

            if (await _accountRepository.ExistsLoginName(entity.LoginName,entity.Uid))
                return result.Failed("用户名已存在");
            if (entity.Phone.NotNull() && await _accountRepository.ExistsPhone(entity.Phone, entity.Uid))
                return result.Failed("手机号已存在");
            if (entity.Email.NotNull() && await _accountRepository.ExistsEmail(entity.Email, entity.Uid))
                return result.Failed("邮箱已存在");
            return result.Success(Guid.Empty);
        }

        public async Task<IResultModel<UserTokenResult>> LoginByName(AccountLoginModel model)
        {
            var result = new ResultModel<UserTokenResult>();

            if (model.LoginName.IsNull())
            {
                return result.Failed("用户名不能为空");

            }
            if (model.LoginPwd.IsNull())
            {
                return result.Failed("登陆密码不能为空");
            }
            var user=await    _accountRepository.GetByLoginName(model.LoginName);
            if (!user.Status)
            {
                return result.Failed("账户未启用");
            }
            if(user.LoginPwd != Zoomtel.Utils.Helpers.Encrypt.DESEncrypt(model.LoginPwd, user.PassSalt))
            {
                return result.Failed("账户密码不正确");

            }
            //修改用户登陆信息
            user.LoginCount++;
            user.LastIp = _loginInfo.IP;
            user.LastUserAgent = _loginInfo.UserAgent;
          await  _accountRepository.UpdateAsync(user);// 这里要加上await 可能出现错误

  


            if (user != null)
            {
             var obj=   Token(user);
                //记录登录日志
                //_loginLogRepository.Insert(new LoginLogEntity
                //{
                //    Id=_loginLogRepository.GetSeq("S_SYS_LOGINLOG").ToString(),
                //    Uid = user.Uid,
                //    LoginIp = user.LastIp,
                //    LoginTime = DateTime.Now,
                //    AccountName = user.LoginName,
                //    Token=obj.access_token


                //});
               _loginLogService.Add(new LoginLogEntity
                {
                   
                    Uid = user.Uid,
                    LoginIp = user.LastIp,
                    LoginTime = DateTime.Now,
                   LoginName = user.LoginName,
                    Token = obj.access_token


                });
                return result.Success(obj);
                
            }
            else
            {
                return result.Failed("用户名不存在");
            }


        }

        private UserTokenResult Token(AccountEntity model)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            var authTime = DateTime.Now;//授权时间
            var expiresAt = authTime.AddDays(30);//过期时间
            var tokenDescripor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(JwtClaimTypes.Audience,_jwtSettings.Audience),
                    new Claim(JwtClaimTypes.Issuer,_jwtSettings.Issuer),
                     new Claim(JwtClaimTypes.Name, model.LoginName),

                    new Claim(Zoomtel.Service.Auth.ClaimTypes.LoginName,model.LoginName),
                    new Claim(Zoomtel.Service.Auth.ClaimTypes.Uid,model.Uid.ToString()),
                    new Claim(Zoomtel.Service.Auth.ClaimTypes.LoginTime,authTime.ToString())

                //new Claim(JwtClaimTypes.Name, model.LoginName),
                //new Claim(JwtClaimTypes.Id, model.Uid.ToString())
            }),
                Expires = expiresAt,
                //对称秘钥SymmetricSecurityKey
                //签名证书(秘钥，加密算法)SecurityAlgorithms
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescripor);
            var tokenString = tokenHandler.WriteToken(token);
            UserTokenResult result = new UserTokenResult();
            result.access_token = tokenString;
            result.expires_at = expiresAt;
            result.name = model.LoginName;
            result.uid = model.Uid.ToString("N");
          
            return result;
        }

        public async Task<IResultModel> StatusChange(Guid uid, bool status)
        {
            var entity = _accountRepository.FindEntity(uid);
            entity.Status = status;
            int i = await _accountRepository.UpdateAsync(entity);
            if (i > 0)
            {
                return ResultModel.Success();

            }
            else
            {
                return ResultModel.Failed();
            }
        }

      
    }
}
