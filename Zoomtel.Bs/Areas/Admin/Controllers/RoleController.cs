using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Zoomtel.Auth.Mvc.Attributes;
using Zoomtel.Entity.Role;
using Zoomtel.Persist.Account.Models;
using Zoomtel.Persist.Role.Models;
using Zoomtel.Service.Account;
using Zoomtel.Service.Account.ViewModels;
using Zoomtel.Service.Role;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zoomtel.Web.Areas.Admin.Controllers
{
     [Description("角色接口")]
    public class RoleController : ModuleController
    {
        RoleService _service;
        public RoleController(RoleService roleService)
        {
            _service = roleService;
             

        }

        [Description("角色管理")]
        [Page]
        [HttpGet]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Description("角色设置")]
        public IActionResult RoleSetting(int roleid)
        {
            ViewBag.roleid = roleid;
            return View();
        }


        [HttpPost]
        public async Task<IResultModel<int>> Update(RoleEntity model)
        {
            return await _service.Update(model);
        }
        [HttpPost]
        public async Task< IResultModel<int>> Add(RoleEntity model)
        {
            return await _service.Add(model);
        }

        //[HttpPost]
        //[Description("多选删除")]
        //public Task<IResultModel<int>> DeleteList([BindRequired]List<int> id)
        //{
        //    return _service.DeleteList(id);
        //}

        [HttpDelete]
        [Description("删除")]
        public Task<IResultModel<int>> Delete(int id)
        {
            return _service.Delete(id);
        }

        [HttpDelete]
        [Description("批量删除")]
        public Task<IResultModel<int>> DeleteList(List<int> ids)
        {
            return _service.DeleteList(ids);


        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<QueryResultModel<RoleEntity>> Query(RuleQueryModel model)
        {
          //model.PageModel = getQueryPageModel();
         
             var result= await _service.Query(model);
            return result.Data;
        }

        [HttpPut]
        public Task< IResultModel> StatusChange(int id,bool status)
        {

            return _service.StatusChange(id, status);
        }

        [HttpGet]
        //[Common]
        public Task<IList<OptionResultModel>> Select()
        {
            return _service.Select();
        }
        [HttpGet]
        [Description("查询平台权限列表")]
        public Task<IResultModel> QueryPermissions([BindRequired]int roleId)
        {
            return _service.QueryPermissions(roleId);
        }
        [HttpPut]
        [Description("绑定平台权限列表")]
        public Task<IResultModel> BindPermissions(RolePermissionBindModel model)
        {
            return _service.BindPermissions(model);
        }


        [HttpPut]
        [Description("绑定角色菜单列表")]
        public Task<IResultModel> BindMenus(RoleMenusBindModel model)
        {

            return _service.BindMenus(model);


        }
        [HttpGet]
        [Description("查询平台权限列表")]
        public Task<IResultModel> QueryMenus([BindRequired]int roleId)
        {
            return _service.QueryMenus(roleId);
        }


        [HttpGet]
        [Description("查询用户权限列表")]
        public Task<IResultModel> QueryByUid([BindRequired]Guid uid)
        {
            return _service.QueryByUid(uid);
        }
    }
}
