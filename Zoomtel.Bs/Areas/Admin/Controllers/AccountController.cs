using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zoomtel.Auth.Mvc.Attributes;
using Zoomtel.Entity;
using Zoomtel.Entity.Account;
using Zoomtel.Persist.Account;
using Zoomtel.Persist.Account.Models;
using Zoomtel.Service.Account;
using Zoomtel.Service.Account.ViewModels;

namespace Zoomtel.Web.Areas.Admin.Controllers
{
   /// <summary>
   /// 账户接口
   /// </summary>
    [Description("账户接口")]
    public class AccountController : ModuleController
    {
        private readonly AccountService _service;
        private readonly ILoginInfo _loginInfo;
        public AccountController(AccountService service,ILoginInfo loginInfo)
        {
            _service = service;
            _loginInfo = loginInfo;

        }
        #region 页面

        
        [Description("账户管理")]
        [Page]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Description("用户登陆")]
        [Page]
        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }
        [AllowAnonymous]
        [Description("退出登陆")]
        [HttpGet]
        [Page]
        public IActionResult Loginout()
        {

            HttpContext.Session.Clear();
            return Redirect("~/admin/account/login");
        }


        #endregion

        #region 接口

        #endregion
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [Description("重置密码")]
        [HttpPut]
        public async Task<IResultModel> ResetPassword(Guid uid)
        {
            return await _service.ResetPassword(uid);

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model">账户查询模型</param>
        /// <returns></returns>
        [Description("查询")]
        [HttpPost]
        public async Task<QueryResultModel<AccountEntity>> Query(AccountQueryModel model)
        {
            //model.PageModel = getQueryPageModel();

            var result = await _service.Query(model);
            return result.Data;
        }

        [HttpPut]
        public Task<IResultModel> StatusChange(Guid uid, bool status)
        {

            return _service.StatusChange(uid, status);
        }


        [Description("获取数据")]
        [HttpGet]
        public async Task<IResultModel> Get(Guid id)
        {
          var data = await _service.Get(id);

            return ResultModel.Success<AccountEntity>(data);
        }

        [HttpPut]
        [Description("修改")]
        public async Task<IResultModel> Update(AccountUpdateModel model)
        {
            return await _service.Update(model);


        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel<Guid>> Add(AccountAddModel model)
        {
            return _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public async Task<IResultModel> Delete(Guid uid)
        {
            return await _service.Delete(uid,_loginInfo.Uid);
        }


    }
}