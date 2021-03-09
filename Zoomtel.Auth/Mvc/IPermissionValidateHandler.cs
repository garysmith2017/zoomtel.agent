﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Zoomtel.Utils.Enums;

namespace Zoomtel.Auth.Mvc
{
    /// <summary>
    /// 权限验证处理接口
    /// </summary>
    public interface IPermissionValidateHandler
    {
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        Task<bool> Validate(IDictionary<string, string> routeValues, HttpMethod httpMethod);
    }
}