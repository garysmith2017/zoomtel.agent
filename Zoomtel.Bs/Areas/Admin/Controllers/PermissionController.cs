using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Zoomtel.Auth;

namespace Zoomtel.Web.Areas.Admin.Controllers
{
    [Description("权限接口")]
    public class PermissionController : ModuleController
    {
        private readonly PermissionCollection _collection;

        public PermissionController(PermissionCollection collection)
        {
            _collection = collection;
        }

        [HttpGet]
        [Description("查询")]
        public IResultModel Query([BindRequired]string moduleCode)
        {
            return ResultModel.Success(_collection.Query(moduleCode));
        }

        [HttpGet]
        [Description("权限树")]
        public JsonResult Tree([FromQuery]bool easyui)
        {
            if (easyui)
            {
                return Json(_collection.Tree.Children);
            }
            else
            {
                return Json( ResultModel.Success(_collection.Tree.Children));

            }

            //}
            //return ResultModel.Success(_collection.Tree);
        }

        [HttpGet]
        [Description("根据编码查询")]
        public IResultModel QueryByCodes([FromQuery] List<string> codes)
        {
            return ResultModel.Success(_collection.Query(codes));
        }



        [HttpGet]
        [Description("查询页面权限")]
        public IActionResult QueryPages()
        {
            return Json(_collection.QueryPage());
        }
    }
}
