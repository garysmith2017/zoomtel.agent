using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Zoomtel.Auth.Mvc;
using Zoomtel.Entity;
using Zoomtel.Utils.Helpers;
using Microsoft.Extensions.Logging;
using Zoomtel.Service;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Zoomtel.Entity;
using System.Linq;
using Zoomtel.Utils.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Zoomtel.Entity.AuditInfo;
using Zoomtel.Service.AuditInfo;

namespace Zoomtel.Service.Auth.Handler
{
    /// <summary>
    /// 审计日志处理
    /// </summary>
    [Singleton]
    public class AuditingHandler : IAuditingHandler
    {
        private readonly MvcHelper _mvcHelper;
        private readonly ILoginInfo _loginInfo;
        private  AuditInfoService _auditInfoService;
         private readonly ILogger _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public void Scoped()
        {
            //using (var scope = _scopeFactory.CreateScope())
            //{
            var scope = _scopeFactory.CreateScope();
                _auditInfoService = scope.ServiceProvider.GetRequiredService<AuditInfoService>();
             
            //}
            // Other code
        }
        public AuditingHandler(MvcHelper mvcHelper, ILoginInfo loginInfo, IServiceScopeFactory scopeFactory,  ILogger<AuditingHandler> logger)
        {
            _mvcHelper = mvcHelper;
            _loginInfo = loginInfo;
            //_auditInfoService = auditInfoService;
            _logger = logger;
            _scopeFactory = scopeFactory;
            Scoped();
        }

        public async Task Hand(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool Auditing = true;
            if (!Auditing)
            {
                await next();
                return;
            }
            var auditInfo = CreateAuditInfo(context);

            var sw = new Stopwatch();
            sw.Start();

            var resultContext = await next();

            sw.Stop();

            if (auditInfo != null)
            {
                try
                {
                    //执行结果
                    if (resultContext.Result is ObjectResult result)
                    {
                        auditInfo.Result = JsonSerializer.Serialize(result.Value);
                    }
                    if(resultContext.Result is JsonResult JsonResult)
                    {
                        auditInfo.Result = JsonSerializer.Serialize(JsonResult.Value);


                    }
                    //用时
                    auditInfo.ExecutionDuration = sw.ElapsedMilliseconds;

                    await _auditInfoService.Add(auditInfo);
                }
                catch (Exception ex)
                {
                    _logger.LogError("审计日志插入异常：{@ex}", ex);
                }
            }

        }

        private AuditInfoEntity CreateAuditInfo(ActionExecutingContext context)
        {
            try
            {
                var routeValues = context.ActionDescriptor.RouteValues;
                var auditInfo = new AuditInfoEntity
                {
                    Uid = _loginInfo.Uid,
                    LoginName = _loginInfo.LoginName,
                    Area = routeValues["area"] ?? "",
                    Controller = routeValues["controller"],
                    Action = routeValues["action"],
                    Parameters = JsonSerializer.Serialize(context.ActionArguments),
                   // Platform = _loginInfo.Platform,
                    IP = _loginInfo.IP,
                    ExecutionTime = DateTime.Now
                };

                //获取模块的名称
                //if (auditInfo.Area.NotNull())
                //{
                //    auditInfo.Module = _moduleCollection.FirstOrDefault(m => m.Code.EqualsIgnoreCase(auditInfo.Area))?.Name;
                //}

                var controllerDescriptor = _mvcHelper.GetAllController().FirstOrDefault(m => m.Area.NotNull() && m.Area.EqualsIgnoreCase(auditInfo.Area) && m.Name.EqualsIgnoreCase(auditInfo.Controller));
                if (controllerDescriptor != null)
                {
                    auditInfo.ControllerDesc = controllerDescriptor.Description;

                    var actionDescription = _mvcHelper.GetAllAction().FirstOrDefault(m => m.Controller == controllerDescriptor && m.Name.EqualsIgnoreCase(auditInfo.Action));
                    if (actionDescription != null)
                    {
                        auditInfo.ActionDesc = actionDescription.Description;
                    }
                }

                //记录浏览器UA
                if (context.HttpContext.Request.Headers.ContainsKey("User-Agent"))
                {
                    auditInfo.BrowserInfo = context.HttpContext.Request.Headers["User-Agent"];
                }

                return auditInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError("审计日志创建异常：{@ex}", ex);
            }

            return null;
        }
    }
}
