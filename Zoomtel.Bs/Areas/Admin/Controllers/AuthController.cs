using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Zoomtel.Entity;
using Zoomtel.Service.Account.ViewModels;
using Zoomtel.Service.Account;
using Microsoft.AspNetCore.Http;
using Zoomtel.Service.Auth;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;

namespace Zoomtel.Web.Areas.Admin.Controllers
{

    [Description("认证接口")]
    public class AuthController : ModuleController
    {
      
        private readonly AccountService _accountservice;
        public AuthController(AccountService accountservice)
        {
         
            _accountservice = accountservice;

        }

     

        /// <summary>
        /// 根据用户名密码获取token
        /// </summary>
        /// <returns></returns>
        [Description("获取Token")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IResultModel<UserTokenResult>> GetToken(AccountLoginModel model)
        {

            var result= await _accountservice.LoginByName(model);
            if (result.Successful)
            {
                HttpContext.Session.SetString("JWToken", result.Data.access_token);


            }
            return result;
        }

     
    }
}