using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zoomtel.Entity.Quartz;
using Zoomtel.Persist.Quartz.Model;
using Zoomtel.Service.Quartz;

namespace Zoomtel.Web.Areas.Admin.Controllers
{
    [Description("定时任务分组接口")]
    public class TaskGroupController : ModuleController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        TaskGroupService _service;
        public TaskGroupController(TaskGroupService service)
        {
            _service = service;


        }


        [HttpPost]
        [Description("修改")]

        public async Task<IResultModel> Update(TaskGroupEntity model)
        {
            return await _service.Update(model);
        }
        [HttpPost]
        [Description("新增")]

        public async Task<IResultModel<Guid>> Add(TaskGroupEntity model)
        {
            return await _service.Add(model);
        }


        [HttpDelete]
        [Description("删除")]
        public Task<IResultModel> Delete(Guid id)
        {
            return _service.Delete(id);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("查询列表")]
        public async Task<QueryResultModel<TaskGroupEntity>> Query(TaskGroupQueryModel model)
        {

            var result = await _service.Query(model);
            return result.Data;
        }

    }
}