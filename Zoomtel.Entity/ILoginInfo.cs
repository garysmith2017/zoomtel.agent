using System;

namespace Zoomtel.Entity
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public interface ILoginInfo
    {
        /// <summary>
        /// 账户编号
        /// </summary>
        Guid Uid { get; }

        /// <summary>
        /// 账户名称
        /// </summary>
        string LoginName { get; }

        /// <summary>
        /// 获取当前用户IP(包含IPv和IPv6)
        /// </summary>
        string IP { get; }

        /// <summary>
        /// 获取当前用户IPv4
        /// </summary>
        string IPv4 { get; }

        /// <summary>
        /// 获取当前用户IPv6
        /// </summary>
        string IPv6 { get; }

        /// <summary>
        /// 登录时间戳
        /// </summary>
        long LoginTime { get; }

        /// <summary>
        /// 获取当前用户请求的User-Agent
        /// </summary>
        string UserAgent { get; }
    }
}
