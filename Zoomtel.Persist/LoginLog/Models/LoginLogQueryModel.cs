using System;
using System.Collections.Generic;
using System.Text;
using Zoomtel.Entity.LoginLog;

namespace Zoomtel.Persist.LoginLog.Models
{
    public class LoginLogQueryModel: Query.QueryModel
    {
       

        public string LoginName { get; set; }

        public string LoginIp { get; set; }

        public DateTime? time_min { get; set; }
        public DateTime? time_max { get; set; }

        public string Remark { get; set; }
    }
}
