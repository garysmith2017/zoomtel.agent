using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.LoginLog
{
    [Table("T_SYS_LOGINLOG")]
    public class LoginLogEntity: BaseEntity
    {

        public string Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid Uid { get; set; }


        public string LoginName { get; set; }

        public string LoginIp { get; set; }

        public DateTime LoginTime { get; set; }

        public string Remark { get; set; }

        public string Token { get; set; }

    }
}
