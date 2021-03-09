using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Persist.Quartz.Model
{
   public class TaskQueryModel : Query.QueryModel
    {
        public string TaskName { get; set; }
        public string TaskCode { get; set; }

    }
}
