using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Entity
{
   public class SoftDeleteInfo
    {
        /// <summary>
        /// 已删除
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletedTime { get; set; } 

        /// <summary>
        /// 删除人
        /// </summary>
        [Nullable]
        public Guid DeletedBy { get; set; }

        /// <summary>
        /// 删除人名称
        /// </summary>
        public string Deleter { get; set; }
    }
}
