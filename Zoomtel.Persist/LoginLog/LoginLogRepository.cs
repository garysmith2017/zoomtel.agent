using EFCoreRepository.DbContexts;
using EFCoreRepository.Extensions;
using EFCoreRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity.LoginLog;
using Zoomtel.Persist.LoginLog.Models;
using Zoomtel.Persist.Query;

namespace Zoomtel.Persist.LoginInfo
{
   public class LoginLogRepository : EFCoreRepository.Repositories.RepositoryAb<LoginLogEntity>
    {

        public LoginLogRepository(DefaultDbContext db) : base(db)
        {


        }

        public async Task<QueryResultModel<LoginLogEntity>> Query(LoginLogQueryModel model)
        {
            var paging = model.Paging();
            var query = dbSet.AsQueryable();
            if (!model.LoginName.IsNull())
            {
                query = query.Where(a => a.LoginName.Equals(model.LoginName));
            }
            if (!model.LoginIp.IsNull())
            {
                query = query.Where(a => a.LoginIp.Equals(model.LoginIp));
            }

            if (model.time_min != null)
            {
                query = query.Where(a => model.time_min < a.LoginTime);
            }
            if (model.time_max != null)
            {
                query = query.Where(a => model.time_max > a.LoginTime);
            }

            if (!paging.OrderBy.Any())
            {
                query = query.OrderByDescending(m => m.Id);
            }
            return await query.PaginationGetResult(paging);
        }
    }
}
