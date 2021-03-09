using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Zoomtel.Entity;
using Zoomtel.Utils.Enums;

namespace Zoomtel.Auth.Mvc.Attributes
{
    /// <summary>
    /// 权限验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionValidateAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //排除匿名访问
            if (context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(AllowAnonymousAttribute)))
                return;

            //var configProvider = context.HttpContext.RequestServices.GetService<IConfigProvider>();
            //var config = configProvider.Get<AuthConfig>();
            ////是否开启权限认证
            //if (!config.Validate)
            //    return;
            

            //未登录
            var loginInfo = context.HttpContext.RequestServices.GetService<ILoginInfo>();
            if (loginInfo == null || loginInfo.Uid.IsEmpty())
            {
                if (context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(PageAttribute)))
                {
                    context.Result = new RedirectResult("/admin/home/LoginOutRun");

                }
                else
                {
                    context.Result = new ChallengeResult();
                }
                return;
            }

            //排除通用接口
            if (context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(CommonAttribute)))
                return;

            var httpMethod = (HttpMethod)Enum.Parse(typeof(HttpMethod), context.HttpContext.Request.Method);
            var handler = context.HttpContext.RequestServices.GetService<IPermissionValidateHandler>();

            if (!await handler.Validate(context.ActionDescriptor.RouteValues, httpMethod))
            {
                if (context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(PageAttribute)))
                {
                    var result = new ContentResult();
                    result.Content = "无权限访问";
                    context.Result = result;

                }
                else
                {

                    //无权访问
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
