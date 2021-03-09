using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.Quartz
{
    /// <summary>
    /// 任务日志类型
    /// </summary>
    public enum JobLogType
    {
        [Description("信息")]
        Info,
        [Description("调试")]
        Debug,
        [Description("异常")]
        Error
    }
    [Table("T_QUARTZ_TASKLOG")]
  public  class TaskLogEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public JobLogType Type { get; set; }

        /// <summary>
        /// 内容信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}
