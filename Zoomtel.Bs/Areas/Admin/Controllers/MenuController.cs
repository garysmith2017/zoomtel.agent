using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zoomtel.Auth.Mvc.Attributes;
using Zoomtel.Entity.Menu;
using Zoomtel.Persist.Menu;
using Zoomtel.Service.Menu;
using Zoomtel.Service.Menu.ViewModels;

namespace Zoomtel.Web.Areas.Admin.Controllers
{
    [Description("菜单接口")]
    public class MenuController : ModuleController
    {

        private readonly MenuService _service;
        public MenuController(MenuService menuService)
        {

            _service = menuService;

        }
        [Description("菜单管理")]
        [Page]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Description("查看")]
        [HttpGet]
        public async Task<IResultModel> Get(int id)
        {
            var data = await _service.View(id);

            return data;
        }



        [HttpPost]
        public async Task<IResultModel<int>> Update(MenuEntity model)
        {
            return await _service.Update(model);
        }
        /// <summary>
        /// 修改菜单显示状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="visible">是否显示</param>
        /// <returns></returns>
        [Description("修改菜单显示状态")]
        [HttpPut]
        public async Task<IResultModel> VisibleChange(int id, bool visible)
        {
            //var model= await _service.View(id);
            //model.vis
            return await _service.ChangeVisible(id, visible);
        }

        /// <summary>
        /// 修改菜单常用状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="often">是否显示</param>
        /// <returns></returns>
        [Description("修改菜单常用状态")]
        [HttpPut]
        public async Task<IResultModel> OftenChange(int id, bool often)
        {
         
            return await _service.ChangeOften(id, often);
        }


        [HttpDelete]
        public async Task<IResultModel<int>> Delete(int id)
        {

            return await _service.Delete(id);
        }
        [HttpPost]
        public async Task<IResultModel<int>> Add(MenuEntity model)
        {
            return await _service.Add(model);
        }



        [HttpGet]
        [Description("菜单树")]
        public async Task<JsonResult> Tree(bool easyui)
        {
            var result = await _service.LoadTree();
            if (easyui)
            {

                return Json(result);
            }
            return Json(ResultModel.Success(result));
        }
        [HttpGet]
        [Description("获取用户菜单树")]
        public async Task<JsonResult> UserTree(bool easyui)
        {
            var result = await _service.LoadUserTree();
            if (easyui)
            {

                return Json(result);
            }
            return Json(ResultModel.Success(result));
        }


        [HttpGet]
        public IActionResult GetMenus(string moduleCode, bool onlydata)
        {
            var list = _service.getMainMenu();
            if (onlydata)
            {
                return Json(list);
            }
            return Json(ResultModel.Success(list));

        }

        [HttpGet]
        public async Task<IActionResult> Select(bool easyui)
        {
            List<TreeResultModel<int, MenuEntity>> list = new List<TreeResultModel<int, MenuEntity>>();
            var result = await _service.LoadTree();

            var NullModel = new TreeResultModel<int, MenuEntity>()
            {
                Id = 0,
                Text = "无上级菜单",
                Children = result

            };
            list.Add(NullModel);
            if (easyui)
            {

                return Json(list);
            }
            return Json(ResultModel.Success(list));
        }



        [HttpGet]
        public IResultModel GetModules()
        {

            List<object> list = new List<object>();
            list.Add(new
            {
                name = "系统管理",
                id = "admin"
            });
            return ResultModel.Success(list);
        }


        [Description("查询")]
        [HttpPost]
        [DisableAuditing]
        public async Task<IResultModel<QueryResultModel<MenuEntity>>> Query(MenuQueryModel model)
        {
            return await _service.Query(model);
        }
    }
}