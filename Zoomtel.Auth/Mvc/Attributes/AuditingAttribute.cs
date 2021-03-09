using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
namespace Zoomtel.Auth.Mvc.Attributes
{
    /// <summary>
    /// 审计标注
    /// </summary>
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    //public class AuditingAttribute : AuthorizeAttribute, IAsyncActionFilter
    public class AuditingAttribute : Attribute, IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //如果禁用审计功能，直接走下一步
            if (CheckDisabled(context))
            {
                return next();
            }

            var handler = context.HttpContext.RequestServices.GetService<IAuditingHandler>();

            return handler.Hand(context, next);
        }
        /// <summary>
        /// 判断是否禁用审计功能
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool CheckDisabled(ActionExecutingContext context)
        {
            //return false;
            return context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(DisableAuditingAttribute));
        }
    }
}
