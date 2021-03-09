using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Quartz.Abstractions;

namespace Zoomtel.Quartz.Core
{
    public class TaskLogger : ITaskLogger
    {
        private readonly ILogger _logger;

        public TaskLogger(ILogger<TaskLogger> logger)
        {
            _logger = logger;
        }

        public Guid TaskId { get; set; }

        public Task Info(string msg)
        {
            _logger.LogInformation($"任务编号:{TaskId}, {msg}");
            return Task.CompletedTask;
        }

        public Task Debug(string msg)
        {
            _logger.LogDebug($"任务编号:{TaskId}, {msg}");
            return Task.CompletedTask;
        }

        public Task Error(string msg)
        {
            _logger.LogError($"任务编号:{TaskId}, {msg}");
            return Task.CompletedTask;
        }
    }
}
