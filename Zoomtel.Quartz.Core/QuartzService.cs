using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Linq;
using System.Threading.Tasks;
using Zoomtel.Quartz.Abstractions;

namespace Zoomtel.Quartz.Core
{
    public class QuartzServer : IQuartzServer
    {
        private IScheduler _scheduler;
        private readonly ILogger _logger;
        private readonly IServiceProvider _container;

        public   QuartzServer(ILogger<QuartzServer> logger, IServiceProvider container)
        {
            _logger = logger;
            _container = container;
            Start();
        }

        /// <summary>
        /// 启动
        /// </summary>
        public async Task Start()
        {
            //var configProvider = _container.GetService<IConfigProvider>();
            //var config = configProvider.Get<QuartzConfig>();
            //if (!config.Enabled)
            //    return;
            //QuartzConfig config = new QuartzConfig();
            //config.ConnectionString = "Data Source=127.0.0.1;Initial Catalog=zoomtel;User ID=sa;Password=sasa;";
            //config.Enabled = true;
            //config.Logger = true;
            //调度器工厂
            //var factory = new StdSchedulerFactory(config.ToProps());

            var factory = new StdSchedulerFactory();


            //创建一个调度器
            _scheduler = await factory.GetScheduler();

            //绑定自定义任务工厂
            _scheduler.JobFactory = new JobFactory(_container);

            //添加任务监听器
            AddJobListener();

            //添加触发器监听器
            AddTriggerListener();

            //添加调度服务监听器
            AddSchedulerListener();

            //启动
            await _scheduler.Start();

            _logger.LogInformation("Quartz server started");
        }

        /// <summary>
        /// 停止
        /// </summary>
        public async Task Stop()
        {
            if (_scheduler == null || _scheduler.IsShutdown)
                return;

            await _scheduler.Shutdown(true);

            _logger.LogInformation("Quartz server stopped");
        }

        /// <summary>
        /// 重启
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task Restart()
        {
            await Stop();
            await Start();
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        public  Task AddJob(IJobDetail jobDetail, ITrigger trigger)
        {
            //if (_scheduler == null || _scheduler.IsShutdown)
            //{

            //    Start().Wait();
            //}
            return  _scheduler.ScheduleJob(jobDetail, trigger);
        }

        /// <summary>
        /// 暂停任务
        /// </summary>
        public Task PauseJob(JobKey jobKey)
        {
            return _scheduler.PauseJob(jobKey);
        }

        /// <summary>
        /// 恢复任务
        /// </summary>
        public Task ResumeJob(JobKey jobKey)
        {
            return _scheduler.ResumeJob(jobKey);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        public Task DeleteJob(JobKey jobKey)
        {
            return _scheduler.DeleteJob(jobKey);
        }

        #region ==私有方法==

        /// <summary>
        /// 添加调度服务监听器
        /// </summary>
        private void AddSchedulerListener()
        {
            var schedulerListeners = _container.GetServices<ISchedulerListener>().ToList();
            if (schedulerListeners.Any())
            {
                foreach (var listener in schedulerListeners)
                {
                    _scheduler.ListenerManager.AddSchedulerListener(listener);
                }
            }
        }

        /// <summary>
        /// 添加任务监听器
        /// </summary>
        private void AddJobListener()
        {
            var jobListeners = _container.GetServices<IJobListener>().ToList();
            if (jobListeners.Any())
            {
                foreach (var listener in jobListeners)
                {
                    _scheduler.ListenerManager.AddJobListener(listener);
                }
            }
        }

        /// <summary>
        /// 添加触发器监听器
        /// </summary>
        private void AddTriggerListener()
        {
            var triggerListener = _container.GetServices<ITriggerListener>().ToList();
            if (triggerListener.Any())
            {
                foreach (var listener in triggerListener)
                {
                    _scheduler.ListenerManager.AddTriggerListener(listener);
                }
            }
        }

        #endregion
    }
}
