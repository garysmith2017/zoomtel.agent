using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zoomtel.Entity.Quartz;
using Zoomtel.Persist.Quartz;

namespace Zoomtel.Service.Quartz
{
    public class SchedulerListener : ISchedulerListener
    {
        private  TaskRepository _repository;
        private readonly IServiceScopeFactory _scopeFactory;

        public void Scoped()
        {
            var scope = _scopeFactory.CreateScope();

            _repository = scope.ServiceProvider.GetRequiredService<TaskRepository>();
      

            // Other code
        }

        public SchedulerListener(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            Scoped();
        }

        public Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken )
        {
            return _repository.UpdateStatus(jobDetail.Key.Group, jobDetail.Key.Name, JobStatus.Running);
        }

        public async Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken )
        {
            //当调度删除任务时，如果任务状态不是已停止，则表示任务已完成，需修改对应状态
            if (!await _repository.HasStop(jobKey.Group, jobKey.Name))
                await _repository.UpdateStatus(jobKey.Group, jobKey.Name, JobStatus.Completed);
        }

        public Task JobPaused(JobKey jobKey, CancellationToken cancellationToken )
        {
            //暂停
            return _repository.UpdateStatus(jobKey.Group, jobKey.Name, JobStatus.Pause);
        }

        public Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task JobsPaused(string jobGroup, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task JobResumed(JobKey jobKey, CancellationToken cancellationToken )
        {
            //恢复
            return _repository.UpdateStatus(jobKey.Group, jobKey.Name, JobStatus.Running);
        }

        public Task JobsResumed(string jobGroup, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task SchedulerInStandbyMode(CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task SchedulerStarted(CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task SchedulerStarting(CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task SchedulerShutdown(CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task SchedulerShuttingdown(CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }

        public Task SchedulingDataCleared(CancellationToken cancellationToken )
        {
            return Task.CompletedTask;
        }
    }
}