using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoomtel.Quartz.Abstractions
{
    /// <summary>
    /// 任务执行上下文
    /// </summary>
    public interface ITaskExecutionContext
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        Guid TaskId { get; set; }

        /// <summary>
        /// Quartz的任务执行上下文
        /// </summary>
        IJobExecutionContext JobExecutionContext { get; set; }
    }
}
