using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Service.Auth
{
   public static class ClaimTypes
    {
     

        /// <summary>
        /// 用户编号
        /// </summary>
        public const string Uid = "uid";

        /// <summary>
        /// 账户名称
        /// </summary>
        public const string LoginName = "ln";

        /// <summary>
        /// 登录时间
        /// </summary>
        public const string LoginTime = "lt";
    }
}
