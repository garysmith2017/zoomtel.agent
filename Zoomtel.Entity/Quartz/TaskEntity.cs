using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.Quartz
{
    /// <summary>
    /// quartz任务表
    /// </summary>
    [Table("T_QUARTZ_TASK")]
   public class TaskEntity: EntityBaseWithMdInfo, BaseEntity
    {
        [Key]
        [JsonConverter(typeof(NullToDefaultConverter<Guid>))]
        public Guid Id { get; set; }

        public string Group { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClassName { get; set; }

        public string TaskName { get; set; }

        public string TaskCode { get; set; }

        //[JsonConverter(typeof(DateTimeConverter), "yyyy/MM/dd")]
        public DateTime BeginDate { get; set; }
        //[JsonConverter(typeof(DateTimeConverter), "yyyy/MM/dd")]
        public DateTime EndDate { get; set; }


        /// <summary>
        /// 触发器类型 0Cron 表达式，1通用模式
        /// </summary>
        public int TriggerType { get; set; }

        /// <summary>
        /// Cron表达式  TriggerType 为0 时生效
        /// </summary>
        public string Cron { get; set; }

        /// <summary>
        /// 间隔时间秒 TriggerType 为1 时生效
        /// </summary>
        public int IntervalInSeconds { get; set; }

        /// <summary>
        /// 执行重复次数   TriggerType 为1 时生效
        /// </summary>
        public int RepeatCount { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public JobStatus Status { get; set; }

    }
}
