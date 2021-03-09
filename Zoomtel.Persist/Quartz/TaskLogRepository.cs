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
   public class TaskLogRepository:RepositoryAb<TaskLogEntity>
    {

        public TaskLogRepository(DefaultDbContext db) : base(db)
        {


        }

        public async Task<QueryResultModel<TaskLogEntity>> QueryAsync(TaskQueryModel model)
        {
            var paging = model.Paging();
            var query = dbSet.AsQueryable();


            if (!paging.OrderBy.Any())
            {
                query = query.OrderByDescending(m => m.CreatedTime);
            }
            return await query.PaginationGetResult(paging);

        }

        public async Task<QueryResultModel<TaskLogEntity>> QueryAsync(TaskLogQueryModel model)
        {
            var paging = model.Paging();
            var query = dbSet.AsQueryable();

            if (!model.TaskId.IsNull())
            {
                query = query.Where(a => a.TaskId==model.TaskId);
            }
            if (!model.Type.IsNull())
            {
                query = query.Where(a => a.Type == model.Type);
            }
            if (!model.Msg.IsNull())
            {
                query = query.Where(a => a.Msg.Contains(model.Msg));
            }
            if (!paging.OrderBy.Any())
            {
                query = query.OrderByDescending(m => m.CreatedTime);
            }
            return await query.PaginationGetResult(paging);
        }
    }
}
