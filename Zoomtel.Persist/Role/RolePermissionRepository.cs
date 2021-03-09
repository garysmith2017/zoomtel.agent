using EFCoreRepository.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Zoomtel.Entity.Account;
using Zoomtel.Entity.Role;

namespace Zoomtel.Persist.Role
{
   public class RolePermissionRepository : EFCoreRepository.Repositories.RepositoryAb<RolePermissionEntity>
    {
        public RolePermissionRepository(DefaultDbContext db) : base(db)
        {


        }

        public async Task<int> DeleteByRole(int roleId)
        {
            return await DeleteAsync(a => a.RoleId == roleId);

        }

        public async Task<IList<string>> QueryByAccount(Guid uid)
        {
            DbSet<AccountRoleEntity> AccountRoleEntitys = DbContext.Set<AccountRoleEntity>();

            var query = from a in dbSet
                        join c in AccountRoleEntitys
on new { roleid=a.RoleId,uid=uid } equals new { roleid=c.RoleId,uid=c.Uid }
                        select
                        a.PermissionCode;
            return await query.ToListAsync<string>();
         

            //return Db.Find(m => m.Platform == platform)
            // .InnerJoin<AccountRoleEntity>((x, y) => x.RoleId == y.RoleId && y.AccountId == accountId)
            // .Select((x, y) => x.PermissionCode)
            // .ToListAsync<string>();
        }

        public async Task<IList<string>> QueryByRole(int roleId)
        {
            var result =await  (from a in dbSet
                                        where a.RoleId == roleId
                                        select new
                                        {
                                            code = a.PermissionCode
                                        }).ToListAsync();
         var list=   result.Select(u => u.code).ToList<string>();
            //.Select(u => u.code).ToList<string>();

            return  list;
        }
    }
}
