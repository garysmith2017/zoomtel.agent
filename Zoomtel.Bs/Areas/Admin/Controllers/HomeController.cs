using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zoomtel.Auth.Mvc.Attributes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zoomtel.Web.Areas.Admin.Controllers
{

    [Description("主控制器")]
    public class HomeController : ModuleController
    {
        [Page]
        [HttpGet]
        [Description("后台公共页")]
        public IActionResult Index()
        {
            return View();
        }

        [Page]
        [HttpGet]
        [Description("后台默认首页")]
        public IActionResult Main()
        {
            return View();
        }


        [Page]
        [HttpGet]
        [DisableAuditing]
        [AllowAnonymous]
        public IActionResult LoginOutRun()
        {

            return View();
        }

        [Page]
        [HttpGet]
        [Description("图标管理")]
        public IActionResult Icons()
        {

            return View();
        }
    }
}
