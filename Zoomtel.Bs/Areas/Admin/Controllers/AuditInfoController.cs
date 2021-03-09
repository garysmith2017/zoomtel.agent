using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zoomtel.Auth.Mvc.Attributes;
using Zoomtel.Entity;
using Zoomtel.Entity.AuditInfo;
using Zoomtel.Persist;
using Zoomtel.Persist.AuditInfo.Models;
using Zoomtel.Service;
using Zoomtel.Service.AuditInfo;

namespace Zoomtel.Web.Areas.Admin.Controllers
{
    [DisableAuditing]
    [Description("审计接口")]
    public class AuditInfoController : ModuleController
    {

        AuditInfoService _service;
        public AuditInfoController(AuditInfoService service)
        {
            _service = service;

        }
        [HttpGet]
        [Page]
        [Description("审计信息")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public async Task<IResultModel> Delete(Guid id)
        {

            return await _service.Delete(id);
        }

        [HttpDelete]
        public async Task<IResultModel> DeleteList(List<Guid> ids)
        {

            return await _service.DeleteList(ids);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        [Description("查询")]
        [HttpPost]
        [DisableAuditing]
        public async Task<QueryResultModel<AuditInfoEntity>> Query(AuditInfoQueryModel model)
        {
            //model.PageModel = getQueryPageModel();

            var result = await _service.Query(model);
            return result.Data;
        }
    }
}