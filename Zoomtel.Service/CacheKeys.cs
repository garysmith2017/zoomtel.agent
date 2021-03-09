using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Zoomtel.Service
{
  public static  class CacheKeys
    {

        /// <summary>
        /// 账户权限列表
        /// <para>ADMIN:ACCOUNT:PERMISSIONS:账户编号</para>
        /// </summary>
        [Description("账户权限列表")]
        public const string ACCOUNT_PERMISSIONS = "ADMIN:ACCOUNT:PERMISSIONS:";
    }
}
