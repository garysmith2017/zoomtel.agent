using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Zoomtel.Persist;
using Zoomtel.Service.Account;

namespace Zoomtel.Web.Controllers
{
    public class TestController : Controller
    {
        AccountService accountService;
        public TestController(AccountService _accountService)
        {

            accountService = _accountService;

        }
      
        [Route("/test/index2")]
        [HttpGet]
        public IActionResult Index2()
        {

            return View();
        }


        [HttpGet]
        //[Route("/test/index")]
        public async Task<IActionResult> Index()
        {

            return Content("123");
            //Service.Account.ViewModels.AccountAddModel model = new Service.Account.ViewModels.AccountAddModel();

            //model.LoginName = "adminadminadminadminadminadminadminadmin";
            //model.LoginPwd = "123";
            //model.RealName = "叶树荣";
            //model.Phone = "18712213213";
            //model.Status = true;
            //model.Roles = new List<int>() { 23, 24 };
            //IResultModel<Guid> result = await accountService.Add(model);
            //return Json(result);
        }

     
        //private JwtSettings _jwtSettings;

        //public TestController( IOptions<JwtSettings> _jwtSettingsAccesser)
        //{
        //    _jwtSettings = _jwtSettingsAccesser.Value;

        //}
        
        //[Route("Account/get_token")]
        //[HttpGet]
        //public IActionResult GetToken()
        //{
        //    return Ok(Token(null));
        //}

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="user"></param>
        //private object Token(User model)
        //{
        //    //测试自己创建的对象
        //    var user = new User
        //    {
        //        id = 1,
        //        phone = "138000000",
        //        password = "e10adc3949ba59abbe56e057f20f883e"
        //    };
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
        //    var authTime = DateTime.Now;//授权时间
        //    var expiresAt = authTime.AddDays(30);//过期时间
        //    var tokenDescripor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[] {
        //            new Claim(JwtClaimTypes.Audience,_jwtSettings.Audience),
        //            new Claim(JwtClaimTypes.Issuer,_jwtSettings.Issuer),
        //            new Claim(JwtClaimTypes.Name, user.phone.ToString()),
        //            new Claim(JwtClaimTypes.Id, user.id.ToString()),
        //            new Claim(JwtClaimTypes.PhoneNumber, user.phone.ToString())
        //        }),
        //        Expires = expiresAt,
        //        //对称秘钥SymmetricSecurityKey
        //        //签名证书(秘钥，加密算法)SecurityAlgorithms
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescripor);
        //    var tokenString = tokenHandler.WriteToken(token);
        //    var result = new
        //    {
        //        access_token = tokenString,
        //        token_type = "Bearer",
        //        profile = new
        //        {
        //            id = user.id,
        //            name = user.phone,
        //            phone = user.phone,
        //            auth_time = authTime,
        //            expires_at = expiresAt
        //        }
        //    };
        //    return result;
        //}
        //[Attribute.Test222]
        //[Route("Account/Index")]
        //[HttpGet]
        //public IActionResult Index()
        //{
         
        //    return Json(_context.Accounts.ToList());
        //}
    }
}