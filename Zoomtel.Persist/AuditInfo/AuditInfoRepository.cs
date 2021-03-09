using EFCoreRepository.DbContexts;
using EFCoreRepository.Extensions;
using EFCoreRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity;
using Zoomtel.Entity.AuditInfo;
using Zoomtel.Persist.AuditInfo.Models;
using Zoomtel.Persist.Query;

namespace Zoomtel.Persist.AuditInfo
{
  public  class AuditInfoRepository : RepositoryAb<AuditInfoEntity>
    {
        public AuditInfoRepository(DefaultDbContext db) : base(db)
        {


        }

        public async Task<QueryResultModel<AuditInfoEntity>> Query(AuditInfoQueryModel model)
        {
            var paging = model.Paging();
            var query = dbSet.AsQueryable();
            if (!model.LoginName.IsNull())
            {
                query = query.Where(a => a.LoginName.Equals(model.LoginName) );
            }
            if (!model.SAction.IsNull())
            {
                query = query.Where(a => a.Action.Equals(model.SAction));
            }
            if (!model.SController.IsNull())
            {
                query = query.Where(a => a.Controller.Equals(model.SController));
            }
            if (model.time_min != null)
            {
                query = query.Where(a =>  model.time_min<a.ExecutionTime);
            }
            if (model.time_max != null)
            {
                query = query.Where(a => model.time_max > a.ExecutionTime );
            }
            //if (!model.LoginName.IsNull())
            //{
            //    query = query.Where(a => a.LoginName.Contains(model.LoginName));
            //}

            if (!paging.OrderBy.Any())
            {
                query = query.OrderByDescending(m => m.ExecutionTime);
            }
            return await query.PaginationGetResult(paging);
        }
    }
}
