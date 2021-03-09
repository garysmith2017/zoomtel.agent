using EFCoreRepository.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Zoomtel.Entity.Role;

namespace Zoomtel.Persist.Role
{
   public class RoleMenuRepository : EFCoreRepository.Repositories.RepositoryAb<RoleMenuEntity>
    {
        public RoleMenuRepository(DefaultDbContext db) : base(db)
        {


        }

        public async Task<int> DeleteByRole(int roleId)
        {
            return await DeleteAsync(a => a.RoleId == roleId);

        }

        public Task<IList<string>> QueryByAccount(Guid uid)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<int>> QueryByRole(int roleId)
        {
            var result = await (from a in dbSet
                                where a.RoleId == roleId
                                select new
                                {
                                    code = a.MenuId
                                }).ToListAsync();
            var list = result.Select(u => u.code).ToList<int>();
            //.Select(u => u.code).ToList<string>();

            return list;
        }
    }
}
