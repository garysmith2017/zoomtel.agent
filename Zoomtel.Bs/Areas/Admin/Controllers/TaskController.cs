using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Zoomtel.Auth.Mvc.Attributes;
using Zoomtel.Entity.Quartz;
using Zoomtel.Persist.Quartz.Model;
using Zoomtel.Service.Quartz;

namespace Zoomtel.Web.Areas.Admin.Controllers
{
    [Description("定时任务接口")]
    public class TaskController : ModuleController
    {
        [Description("定时任务管理")]
        [Page]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        TaskService _service;
        public TaskController(TaskService service)
        {
            _service = service;


        }

        [HttpPost]
        [Description("启动任务")]
        public Task<IResultModel> Start([BindRequired]Guid id)
        {
            return _service.Start(id);
        }

        [HttpPost]
        [Description("暂停")]
        public Task<IResultModel> Pause([BindRequired]Guid id)
        {
            return _service.Pause(id);
        }

        [HttpPost]
        [Description("回复")]
        public Task<IResultModel> Resume([BindRequired]Guid id)
        {
            return _service.Resume(id);
        }

        [HttpPost]
        [Description("停止")]
        public Task<IResultModel> Stop([BindRequired]Guid id)
        {
            return _service.Stop(id);
        }

        [HttpPost]
        [Description("Select列表")]
        public Task<IList<OptionResultModel>> Select()
        {
            return  _service.Select();
        }

        [HttpPost]
        [Description("修改")]

        public async Task<IResultModel> Update(TaskEntity model)
        {
            return await _service.Update(model);
        }
        [HttpPost]
        [Description("新增")]

        public async Task<IResultModel> Add(TaskEntity model)
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
        public async Task<QueryResultModel<TaskEntity>> Query(TaskQueryModel model)
        {

            var result = await _service.Query(model);
            return result.Data;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("日志")]
        public async Task<QueryResultModel<TaskLogEntity>> Log(TaskLogQueryModel model)
        {

            var result = await _service.LogQuery(model);
            return result.Data;
        }
    }
}