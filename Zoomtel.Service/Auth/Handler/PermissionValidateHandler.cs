using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Auth.Mvc;
using Zoomtel.Entity;
using Zoomtel.Persist.Account;
using Zoomtel.Utils.Attributes;
using Zoomtel.Utils.Enums;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Zoomtel.Service.Auth.Resolver;
using Zoomtel.Cache;

namespace Zoomtel.Service.Auth.Handler
{
    /// <summary>
    /// 权限验证
    /// </summary>
    [Singleton]
    public class PermissionValidateHandler : IPermissionValidateHandler
    {
        IServiceScopeFactory _scopeFactory;

        private readonly ILoginInfo _loginInfo;
        private IAccountPermissionResolver _permissionResolver;
        //public void Scoped()
        //{
        //    //using (var scope = _scopeFactory.CreateScope())
        //    //{
        //    var scope = _scopeFactory.CreateScope();

        //    //}
        //    // Other code
        //}
        public PermissionValidateHandler(ICacheHandler cache, ILoginInfo logininfo, IAccountPermissionResolver permissionResolver)
        {
            _loginInfo = logininfo;
            _permissionResolver = permissionResolver;
            //_scopeFactory = scopeFactory;
            //Scoped();

        }



        public async Task<bool> Validate(IDictionary<string, string> routeValues, HttpMethod httpMethod)
        {
            return true;
            //var permissions =await _rolePermissionRepository.QueryByAccount(_loginInfo.Uid);

            var permissions =await _permissionResolver.Resolve(_loginInfo.Uid);
            var area = routeValues["area"];
            var controller = routeValues["controller"];
            var action = routeValues["action"];
            return permissions.Any(m => m.EqualsIgnoreCase($"{area}_{controller}_{action}_{httpMethod}"));

        }
    }
}
