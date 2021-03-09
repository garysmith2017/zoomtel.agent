using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zoomtel.Quartz.Abstractions
{
    public abstract class TaskAbstract : ITask
    {
        protected readonly ITaskLogger Logger;

        protected TaskAbstract(ITaskLogger logger)
        {
            Logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var TaskId = context.JobDetail.JobDataMap["id"];
            Logger.TaskId = TaskId == null ? Guid.Empty : Guid.Parse(TaskId.ToString());

            await Logger.Info("任务开始");

            try
            {
                await Execute(new TaskExecutionContext
                {
                    TaskId = Logger.TaskId,
                    JobExecutionContext = context
                });
            }
            catch (Exception ex)
            {
                await Logger.Error("任务异常：" + ex);
            }

            await Logger.Info("任务结束");
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract Task Execute(ITaskExecutionContext context);
    }
}
