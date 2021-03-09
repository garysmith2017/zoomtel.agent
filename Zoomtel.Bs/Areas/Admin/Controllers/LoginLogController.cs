using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Zoomtel.Auth.Mvc.Attributes;
using Zoomtel.Entity.LoginLog;
using Zoomtel.Persist.LoginLog.Models;
using Zoomtel.Service.LoginLog;

namespace Zoomtel.Web.Areas.Admin.Controllers
{
    [Description("登陆日志接口")]
    public class LoginLogController : ModuleController
    {
        private readonly LoginLogService _service;
        public LoginLogController(LoginLogService service)
        {

            _service = service;

        }
        [Page]
        [HttpGet]
        [Description("登陆日志")]
        public IActionResult Index()
        {


            return View();
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        [Description("查询")]
        [HttpPost]
        //[DisableAuditing]
        public async Task<QueryResultModel<LoginLogEntity>> Query(LoginLogQueryModel model)
        {
      
            var result = await _service.Query(model);
            return result.Data;
        }


        [HttpDelete]
        public async Task<IResultModel> Delete(string id)
        {

            return await _service.Delete(id);
        }

        [HttpDelete]
        public async Task<IResultModel> DeleteList(List<string> ids)
        {

            return await _service.DeleteList(ids);
        }
    }
}
