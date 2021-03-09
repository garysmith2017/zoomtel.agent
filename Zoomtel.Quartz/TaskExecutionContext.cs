using System;
using Quartz;

namespace Zoomtel.Quartz.Abstractions
{
    public class TaskExecutionContext : ITaskExecutionContext
    {
        public Guid TaskId { get; set; }
        public IJobExecutionContext JobExecutionContext { get; set; }
    }
}