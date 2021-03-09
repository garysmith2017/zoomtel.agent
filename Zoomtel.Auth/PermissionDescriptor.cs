using System;
using Zoomtel.Utils;
using Zoomtel.Utils.Enums;

namespace Zoomtel.Auth
{
    /// <summary>
    /// 权限描述符
    /// </summary>
    public class PermissionDescriptor
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模块编码
        /// </summary>
        public string ModuleCode { get; set; }

        /// <summary>
        /// 控制名称
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// 是否页面权限
        /// </summary>
        public bool IsPage { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// 唯一编码
        /// </summary>
        public string Code => $"{ModuleCode}_{Controller}_{Action}_{HttpMethod.ToDescription()}".ToLower();
    }
}
