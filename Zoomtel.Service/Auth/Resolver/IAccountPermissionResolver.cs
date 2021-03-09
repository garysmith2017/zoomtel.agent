using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zoomtel.Service.Auth.Resolver
{
    /// <summary>
    /// 账户权限解析接口
    /// </summary>
    public interface IAccountPermissionResolver
    {
        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="accountId">账户编号</param>
        /// <returns></returns>
        Task<IList<string>> Resolve(Guid accountId);

        /// <summary>
        /// 解析菜单列表
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        //Task<IList<AccountMenuItem>> ResolveMenus(Guid accountId);

        /// <summary>
        /// 解析页面编码列表
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        //Task<IList<string>> ResolvePages(Guid accountId);

        /// <summary>
        /// 解析按钮编码列表
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        //Task<IList<string>> ResolveButtons(Guid accountId);
    }
}
