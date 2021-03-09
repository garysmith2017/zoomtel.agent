using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity.Quartz;
using Zoomtel.Persist.Quartz;
using Zoomtel.Quartz.Abstractions;

namespace Zoomtel.Service.Quartz
{
    public class TaskLogger : ITaskLogger
    {
        private  TaskLogRepository _repository;
        private readonly IServiceScopeFactory _scopeFactory;
        public void Scoped()
        {
            var scope = _scopeFactory.CreateScope();

            _repository = scope.ServiceProvider.GetRequiredService<TaskLogRepository>();


            // Other code
        }
        public TaskLogger(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            Scoped();

        }

        public Guid TaskId { get; set; }

        public async Task Debug(string msg)
        {
         

            var entity = new TaskLogEntity
            {
                Id=Guid.NewGuid(),
                TaskId = TaskId,
                Type = JobLogType.Debug,
                Msg = msg,
                CreatedTime = DateTime.Now
            };

            await _repository.InsertAsync(entity);
        }

        public async Task Error(string msg)
        {

            var entity = new TaskLogEntity
            {
                Id = Guid.NewGuid(),
                TaskId = TaskId,
                Type = JobLogType.Error,
                Msg = msg,
                CreatedTime = DateTime.Now
            };

            await _repository.InsertAsync(entity);
        }

        public async Task Info(string msg)
        {
            var entity = new TaskLogEntity
            {
                Id = Guid.NewGuid(),
                TaskId = TaskId,
                Type = JobLogType.Info,
                Msg = msg,
                CreatedTime = DateTime.Now
            };

            await _repository.InsertAsync(entity);
        }
    }
}
