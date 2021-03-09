using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity.Quartz;
using Zoomtel.Persist.Quartz;
using Zoomtel.Persist.Quartz.Model;
using Zoomtel.Quartz.Abstractions;
using Zoomtel.Quartz.Core;

namespace Zoomtel.Service.Quartz
{
    public class TaskService 
    {
        QuartzTaskCollection _collect;
        TaskRepository _repository;
        TaskLogRepository _logRepository;

        IQuartzServer _quartzServer;
        ILogger _logger;
        public TaskService(TaskRepository repository,TaskLogRepository logRepository, ILogger<TaskService> logger, QuartzTaskCollection collect, IQuartzServer quartzServer)
        {
            _repository = repository;
            _logRepository = logRepository;
            _collect = collect;
            _quartzServer = quartzServer;
            _logger = logger;
        }

        public async Task<IResultModel> Add(TaskEntity model)
        {
          
            model.Id = Guid.NewGuid();

            if ( _repository.Exists(m=>m.Group == model.Group&&m.TaskCode==model.TaskCode))
            {
                return ResultModel.Failed($"当前任务组{model.Group}已存在任务编码${model.TaskCode}");
            }
            model.Status = JobStatus.Stop;
            model.EndDate = model.EndDate.AddDays(1);

            int i = await _repository.InsertAsync(model);
            if (i > 0)
            {

                return ResultModel.Success();
            }
            else
            {
                return ResultModel.Failed();

            }

        }

        public async Task<IResultModel> Delete(Guid id)
        {

            var entity = await _repository.FindEntityAsync(id);
            if (entity == null)
            {
                return ResultModel.NotExists;
            }

            if (entity.Status != JobStatus.Stop && entity.Status != JobStatus.Completed)
            {
                var jobKey = new JobKey(entity.TaskCode, entity.Group);
                await _quartzServer.DeleteJob(jobKey);
            }

      

            int result = await _repository.DeleteAsync(id);
            if (result > 0)
            {
                return ResultModel.Success();

            }
            else
            {
                return ResultModel.Failed();
            }
        }

        public async Task<IResultModel> Find(Guid id)
        {
            return ResultModel.Success(_repository.FindEntity(id));
        }

        public async Task<IResultModel<QueryResultModel<TaskEntity>>> Query(TaskQueryModel model)
        {

            var result = new ResultModel<QueryResultModel<TaskEntity>>();

            var data = await _repository.QueryAsync(model);

            return result.Success(data);
        }

        public async Task<IList<OptionResultModel>> Select()
        {
            var list = _collect.Select(m => new OptionResultModel
            {
                Label = m.Name,
                Value = m.Class
            }).ToList();

            return list;
            //IList<OptionResultModel> list=new 
        }

        public async Task<IResultModel> Start(Guid id)
        {
            var entity = await _repository.FindEntityAsync(id);
            if (entity == null)
            {
                return ResultModel.Failed();
            }

            return await AddJob(entity,true);

        }
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="start">是否立即启动</param>
        /// <returns></returns>
        private async Task<IResultModel> AddJob(TaskEntity entity, bool start = false)
        {
            var jobClassType = Type.GetType(entity.ClassName);
            if (jobClassType == null)
            {
                return ResultModel.Failed($"任务类({entity.ClassName})不存在");
            }

            var jobKey = new JobKey(entity.TaskCode, entity.Group);
            var job = JobBuilder.Create(jobClassType).WithIdentity(jobKey)
                .UsingJobData("id", entity.Id.ToString()).Build();
            
            var triggerBuilder = TriggerBuilder.Create().WithIdentity(entity.TaskCode, entity.Group)
                .EndAt(entity.EndDate.ToUniversalTime())
                .WithDescription(entity.TaskName);

            //如果开始日期小于等于当前日期则立即启动
            if (entity.BeginDate <= DateTime.Now)
            {
                triggerBuilder.StartNow();
            }
            else
            {
                triggerBuilder.StartAt(entity.BeginDate.ToUniversalTime());
            }

            if (entity.TriggerType == 1)
            {
                //简单任务
                triggerBuilder.WithSimpleSchedule(builder =>
                {
                    builder.WithIntervalInSeconds(entity.IntervalInSeconds);
                    if (entity.RepeatCount > 0)
                    {
                        builder.WithRepeatCount(entity.RepeatCount - 1);
                    }
                    else
                    {
                        builder.RepeatForever();
                    }
                });
            }
            else
            {
                if (!CronExpression.IsValidExpression(entity.Cron))
                {
                    return ResultModel.Failed("CRON表达式无效");
                }

                //CRON任务
                triggerBuilder.WithCronSchedule(entity.Cron);
            }

            var trigger = triggerBuilder.Build();
            try
            {
                await _quartzServer.AddJob(job, trigger);

                if (!start)
                {
                    //先暂停
                    await _quartzServer.PauseJob(jobKey);
                }

                return ResultModel.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError("任务调度添加任务失败{@ex}", ex);
            }

            return ResultModel.Failed();
        }
    

    public async Task<IResultModel> Update(TaskEntity model)
        {

            if (await _repository.Exists(model))
            {
                return ResultModel.Failed($"当前任务组{model.Group}已存在任务编码${model.TaskCode}");
            }
            //如果任务不是停止或者已完成，先删除在添加
            if (model.Status != JobStatus.Stop && model.Status != JobStatus.Completed)
            {
                var jobKey = new JobKey(model.TaskCode, model.Group);
                await _quartzServer.DeleteJob(jobKey);

                var result = await AddJob(model, model.Status == JobStatus.Running);
                if (!result.Successful)
                {
                    return result;
                }
            }
            int i = await _repository.UpdateAsync(model);
            if (i > 0)
            {

                return ResultModel.Success();
            }
            else
            {
                return ResultModel.Failed();

            }
        }

        public async Task<IResultModel> Pause(Guid id)
        {
            var entity = await _repository.FindEntityAsync(id);
            if (entity == null)
            {
                return ResultModel.Failed("任务不存在");
            }

            if (entity.Status == JobStatus.Stop)
            {
                return ResultModel.Failed("任务已停止，无法暂停");
            }

            if (entity.Status == JobStatus.Completed)
            {
                return ResultModel.Failed("任务已完成，无法暂停");
            }

            if (entity.Status == JobStatus.Pause)
            {
                return ResultModel.Failed("任务已暂停，请刷新页面");
            }

            var jobKey = new JobKey(entity.TaskCode, entity.Group);
            await _quartzServer.PauseJob(jobKey);
            return ResultModel.Success();
        }

        public async Task<IResultModel> Resume(Guid id)
        {
            var entity = await _repository.FindEntityAsync(id);
            if (entity == null)
            {
                return ResultModel.Failed();
            }

            if (entity.Status == JobStatus.Running)
            {
                return ResultModel.Failed("任务已启动，请刷新页面");
            }

            //停止的或者已完成的任务，重启需要重新加入到调度中
            if (entity.Status == JobStatus.Stop || entity.Status == JobStatus.Completed)
            {
                if (entity.EndDate <= DateTime.Now)
                {
                    return ResultModel.Failed("任务时效已过期");
                }

                var result = await AddJob(entity, true);
                if (!result.Successful)
                {
                    return result;
                }
            }
            else
            {
                var jobKey = new JobKey(entity.TaskCode, entity.Group);
                await _quartzServer.ResumeJob(jobKey);
            }
            return ResultModel.Success();
        }

        public async Task<IResultModel> Stop(Guid id)
        {
            var entity = await _repository.FindEntityAsync(id);
            if (entity == null)
            {
                return ResultModel.Failed();
            }

            if (entity.Status == JobStatus.Stop)
            {
                return ResultModel.Failed("任务已停止，请刷新页面");
            }
            if (entity.Status == JobStatus.Completed)
            {
                return ResultModel.Failed("任务已完成，无法停止");
            }

            if (await _repository.UpdateStatus(id, JobStatus.Stop))
            {
                var jobKey = new JobKey(entity.TaskCode, entity.Group);
                await _quartzServer.DeleteJob(jobKey);

                return ResultModel.Success();
            }

            return ResultModel.Failed();
        }

        public async Task<IResultModel<QueryResultModel<TaskLogEntity>>> LogQuery(TaskLogQueryModel model)
        {
            var result = new ResultModel<QueryResultModel<TaskLogEntity>>();

            var data = await _logRepository.QueryAsync(model);

            return result.Success(data);
        }
    }
}
