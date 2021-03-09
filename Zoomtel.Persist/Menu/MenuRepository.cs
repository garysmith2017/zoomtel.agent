using EFCoreRepository.DbContexts;
using EFCoreRepository.Extensions;
using EFCoreRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Persist.Query;
using Zoomtel.Entity.Account;
using Zoomtel.Entity.Role;
using Zoomtel.Entity.Menu;

namespace Zoomtel.Persist.Menu
{
   public class MenuRepository : RepositoryAb<MenuEntity>
    {
        public MenuRepository(DefaultDbContext db) : base(db)
        {
            

        }

        public async Task<List<MenuEntity>> GetListByUser()
        {
            var uid = DbContext.LoginInfo.Uid;
            DbSet<AccountRoleEntity> AccountRoleEntitys = DbContext.Set<AccountRoleEntity>();
            DbSet<RoleMenuEntity> RoleMenuEntitys = DbContext.Set<RoleMenuEntity>();

            var query = from menu in dbSet
                        join a in RoleMenuEntitys on menu.Id equals a.MenuId
                        join c in AccountRoleEntitys on new { roleid = a.RoleId, uid = uid } equals new { roleid = c.RoleId, uid = c.Uid }
                        select
                        menu;
            return await query.Distinct().ToListAsync();




        }

        public async Task<QueryResultModel<MenuEntity>> Query(MenuQueryModel model)
        {
            var paging = model.Paging();
            var query = dbSet.AsQueryable();
            if (!model.Code.IsNull())
            {
                query = query.Where(a => a.Code.Contains(model.Code));
            }
            if (!model.MenuName.IsNull())
            {
                query = query.Where(a => a.MenuName.Contains(model.MenuName));
            }
            if (!model.Url.IsNull())
            {
                query = query.Where(a => a.Url.Contains(model.Url));
            }
            if (!paging.OrderBy.Any())
            {
                query = query.OrderByDescending(m => m.Seq);
            }
            //query.Skip()
            return await query.PaginationGetResult(paging);
        }
    }
}
