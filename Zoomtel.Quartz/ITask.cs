using Quartz;
using System;
using System.Threading.Tasks;

namespace Zoomtel.Quartz.Abstractions
{
    public interface ITask :IJob
    {
        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task Execute(ITaskExecutionContext context);
    }
}
