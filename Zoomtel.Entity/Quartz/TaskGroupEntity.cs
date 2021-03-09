using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.Quartz
{
    /// <summary>
    /// Quartz任务分组表
    /// </summary>
    [Table("T_QUARTZ_TASKGROUP")]
  public  class TaskGroupEntity:BaseEntity
    {

        [Key]
        [JsonConverter(typeof(NullToDefaultConverter<Guid>))]
        public Guid Id { get; set; } = Guid.Empty;


        public string GroupCode { get; set; }

        public string GroupName { get; set; }


    }
}
