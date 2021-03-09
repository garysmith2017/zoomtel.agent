using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Zoomtel.Quartz.Abstractions;

namespace Zoomtel.Service.QuartzTasks
{
    [Description("测试任务")]
    public class TestTask : TaskAbstract
    {
        ITaskLogger _logger;
        public TestTask(ITaskLogger logger) : base(logger)
        {
            _logger = logger;

        }
        public async override Task Execute(ITaskExecutionContext context)
        {
            await Task.Run(() =>
            {

                _logger.Error("任务写入日志出现错误！");

                System.IO.File.AppendAllText(@"D:\test.txt", DateTime.Now + context.TaskId.ToString()+ Environment.NewLine);
            });

        }
    }
}
