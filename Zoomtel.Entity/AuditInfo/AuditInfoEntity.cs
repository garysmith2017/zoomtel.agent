using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.AuditInfo
{
   [Table("T_SYS_AUDITINFO")]
  public  class AuditInfoEntity:BaseEntity
    {


        public Guid Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid Uid { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 区域(模块编码)
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// 控制器描述
        /// </summary>
        public string ControllerDesc { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 操作描述
        /// </summary>
        public string ActionDesc { get; set; }

        /// <summary>
        /// 参数(Json序列化)
        /// </summary>

        public string Parameters { get; set; }

        /// <summary>
        /// 返回值(Json序列化)
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 方法开始执行时间
        /// </summary>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// 方法执行总用时(ms)
        /// </summary>
        public long ExecutionDuration { get; set; }

        /// <summary>
        /// 浏览器信息
        /// </summary>
        [MaxLength(500)]
        public string BrowserInfo { get; set; }


        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }


    }
}
