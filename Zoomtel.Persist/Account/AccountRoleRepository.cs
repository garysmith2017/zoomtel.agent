using EFCoreRepository.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Zoomtel.Entity.Account;
using Zoomtel.Entity.Role;
using Zoomtel.Persist.Account;

namespace Zoomtel.Persist.Account
{
   public class AccountRoleRepository : EFCoreRepository.Repositories.RepositoryAb<AccountRoleEntity>
    {

        public AccountRoleRepository(DefaultDbContext db) : base(db)
        {


        }
       
        public async Task<IList<RoleEntity>> QueryRole(Guid Uid)
        {
            DbSet<RoleEntity> RoleEntitys = DbContext.Set<RoleEntity>();
            var query = from roleAccount in dbSet
                        join c in RoleEntitys
on roleAccount.RoleId equals c.Id
where roleAccount.Uid==Uid
                        select
                        c;

            return await query.ToListAsync();
                    
            //return dbSet.Where(m => m.Uid == Uid).Join<RoleEntitys>((x,y)=>)
            //              .InnerJoin<RoleEntity>((x, y) => x.RoleId == y.Id)
            //              .Select((x, y) => new { y })
            //              .ToListAsync<RoleEntity>();
        }
    }
}
