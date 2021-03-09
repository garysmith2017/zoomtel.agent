using System;
using System.Collections.Generic;
using System.Text;
using Zoomtel.Entity.Quartz;

namespace Zoomtel.Persist.Quartz.Model
{
   public class TaskLogQueryModel : Query.QueryModel
    {
        public Guid TaskId { get; set; }
        public string Msg { get; set; }
        public JobLogType? Type { get; set; }

    }
}
