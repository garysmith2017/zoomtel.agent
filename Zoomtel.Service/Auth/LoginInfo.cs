using System;
using System.Collections.Generic;
using System.Text;
using Zoomtel.Entity;
using Microsoft.AspNetCore.Http;
using Zoomtel.Utils.Attributes;

namespace Zoomtel.Service.Auth
{
    [Singleton]
    public class LoginInfo:ILoginInfo

    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginInfo(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid Uid {
            get
            {
                var accountId = _contextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Uid);

                if (accountId != null && accountId.Value.NotNull())
                {
                    return new Guid(accountId.Value);
                }

                return Guid.Empty;
            }
        }

        public string LoginName
        {
            get
            {
                var accountName = _contextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.LoginName);

                if (accountName == null || accountName.Value.IsNull())
                {
                    return "";
                }

                return accountName.Value;
            }

        }


        /// <summary>
        /// 获取当前用户IP(包含IPv和IPv6)
        /// </summary>
        public string IP
        {
            get
            {
                if (_contextAccessor?.HttpContext?.Connection == null)
                    return "";

                return _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
        }

        /// <summary>
        /// 获取当前用户IPv4
        /// </summary>
        public string IPv4
        {
            get
            {
                if (_contextAccessor?.HttpContext?.Connection == null)
                    return "";

                return _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }

        /// <summary>
        /// 获取当前用户IPv6
        /// </summary>
        public string IPv6
        {
            get
            {
                if (_contextAccessor?.HttpContext?.Connection == null)
                    return "";

                return _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();
            }
        }

        /// <summary>
        /// 登录时间
        /// </summary>
        public long LoginTime
        {
          
            get
            {
                var ty = _contextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.LoginTime);

                if (ty != null && ty.Value.NotNull())
                {
                    return ty.Value.ToLong();
                }

                return 0L;
            }
        }

        /// <summary>
        /// User-Agent
        /// </summary>
        public string UserAgent
        {
            get
            {
                if (_contextAccessor?.HttpContext?.Request == null)
                    return "";

                return _contextAccessor.HttpContext.Request.Headers["User-Agent"];
            }
        }
    }
}
