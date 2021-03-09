using EFCoreRepository.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Persist.Query;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EFCoreRepository.Extensions;
using Zoomtel.Entity.Role;
using Zoomtel.Persist.Role.Models;

namespace Zoomtel.Persist.Role
{
  public  class RoleRepository : EFCoreRepository.Repositories.RepositoryAb<RoleEntity>
    {
        public RoleRepository(DefaultDbContext db) : base(db)
        {


        }

        public async Task<QueryResultModel<RoleEntity>> Query(RuleQueryModel model)
        {
           
            var paging = model.Paging();
            var query = dbSet.AsQueryable();
            if (!model.RoleName.IsNull())
            {
               query= query.Where(a => a.RoleName.Contains(model.RoleName));
            }
            if (!paging.OrderBy.Any())
            {
                query = query.OrderByDescending(m => m.Id);
            }
            //query.Skip()
          return await query.PaginationGetResult(paging);
 
        }
    }
}
