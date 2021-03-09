using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Persist.AuditInfo.Models
{
   public class AuditInfoQueryModel : Query.QueryModel
    {
        public string SController { get; set; }
        public string SAction { get; set; }
        public string LoginName { get; set; }
        public DateTime? time_min { get; set; }
        public DateTime? time_max { get; set; }
    }
}
