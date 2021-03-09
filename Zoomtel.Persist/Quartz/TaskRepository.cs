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
   public class TaskRepository:RepositoryAb<TaskEntity>
    {

        public TaskRepository(DefaultDbContext db) : base(db)
        {


        }

        public async Task<bool> Exists(TaskEntity model)
        {
            return dbSet.Where(a => a.Group == model.Group && a.TaskCode == model.TaskCode && a.Id != model.Id).Any();

        }

        public async  Task<bool> HasStop(string group, string code)
        {
            //await Task.Run(() =>
            //{


            //});

  
                return  Exists(a => a.Group == group&&a.TaskCode== code && a.Status == JobStatus.Stop);


        }

        public async Task<QueryResultModel<TaskEntity>> QueryAsync(TaskQueryModel model)
        {
            var paging = model.Paging();
            var query = dbSet.AsQueryable();

            if (!model.TaskName.IsNull())
            {
                query = query.Where(a => a.TaskName.Contains(model.TaskName));
            }

            if (!paging.OrderBy.Any())
            {
                query = query.OrderByDescending(m => m.CreatedTime);
            }
            return await query.PaginationGetResult(paging);

        }

        public async Task<bool> UpdateStatus(Guid id, JobStatus status)
        {
            FindEntity(id).Status = status;
            int result=await   DbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateStatus(string group, string code, JobStatus status)
        {
         var entity=   dbSet.Where(a => a.Group == group && a.TaskCode == code).FirstOrDefault();
            entity.Status = status;
       return await   DbContext.SaveChangesAsync()>0;
            //return UpdateStatus(Id, status);
        }
    }
}
