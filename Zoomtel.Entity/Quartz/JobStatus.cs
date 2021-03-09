using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Zoomtel.Entity.Quartz
{
   public enum JobStatus
    {
        [Description("停止")]
        Stop,
        [Description("运行")]
        Running,
        [Description("暂停")]
        Pause,
        [Description("已完成")]
        Completed,
        [Description("异常")]
        Exception
    }
}
