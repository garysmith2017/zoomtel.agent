using EFCoreRepository.DbContexts;
using EFCoreRepository.Extensions;
using EFCoreRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity.Quartz;
using Zoomtel.Persist.Quartz.Model;
using Zoomtel.Persist.Query;

namespace Zoomtel.Persist.Quartz
{
   public class TaskGroupRepository:RepositoryAb<TaskGroupEntity>
    {

        public TaskGroupRepository(DefaultDbContext db) : base(db)
        {


        }

        public async Task<QueryResultModel<TaskGroupEntity>> Query(TaskGroupQueryModel model)
        {
            var paging = model.Paging();
            var query = dbSet.AsQueryable();
           
            if (!model.GroupName.IsNull())
            {
                query = query.Where(a => a.GroupName.Contains(model.GroupName) );
            }

            if (!paging.OrderBy.Any())
            {
                query = query.OrderByDescending(m => m.GroupCode);
            }
            return await query.PaginationGetResult(paging);
        }
    }
}
