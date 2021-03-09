using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace Zoomtel.Quartz.Abstractions
{
    /// <summary>
    /// Quartz服务接口
    /// </summary>
    public interface IQuartzServer
    {
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task Start();

        /// <summary>
        /// 停止
        /// </summary>
        /// <returns></returns>
        Task Stop();

        /// <summary>
        /// 重启
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task Restart();

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="jobDetail"></param>
        /// <param name="trigger"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task AddJob(IJobDetail jobDetail, ITrigger trigger);

        /// <summary>
        /// 暂停任务
        /// </summary>
        /// <param name="jobKey"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task PauseJob(JobKey jobKey);

        /// <summary>
        /// 恢复任务
        /// </summary>
        /// <param name="jobKey"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task ResumeJob(JobKey jobKey);

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="jobKey"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task DeleteJob(JobKey jobKey);
    }
}
