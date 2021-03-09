using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Cache;
using Zoomtel.Persist.Account;
using Zoomtel.Persist.Role;
using Zoomtel.Utils.Attributes;

namespace Zoomtel.Service.Auth.Resolver
{
    /// <summary>
    /// 默认权限解析器
    /// </summary>
    [Singleton]
    public class DefaultAccountPermissionResolver : IAccountPermissionResolver
    {
        IServiceScopeFactory _scopeFactory;
        private readonly ICacheHandler _cache;

        private RolePermissionRepository _rolePermissionRepository;
        public void Scoped()
        {
            //using (var scope = _scopeFactory.CreateScope())
            //{
            var scope = _scopeFactory.CreateScope();
            _rolePermissionRepository = scope.ServiceProvider.GetRequiredService<RolePermissionRepository>();

            //}
            // Other code
        }
        public DefaultAccountPermissionResolver(ICacheHandler cache, IServiceScopeFactory scopeFactory)
        {
            _cache = cache;

            _scopeFactory = scopeFactory;
            Scoped();
        }

        public async Task<IList<string>> Resolve(Guid uid)
        {
            if (uid.IsEmpty())
                return new List<string>();

            var key = $"{CacheKeys.ACCOUNT_PERMISSIONS}{uid}";

            if (!_cache.TryGetValue(key, out IList<string> list))
            {
                list = await _rolePermissionRepository.QueryByAccount(uid);
                await _cache.SetAsync(key, list);
            }

            return list;
        }
    }
}
