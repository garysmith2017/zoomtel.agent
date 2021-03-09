using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.Role
{
    /// <summary>
    /// 权限菜单关联表
    /// </summary>
    [Table("T_SYS_ROLEMENUS")]
   public class RoleMenuEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int MenuId { get; set; }
        public int RoleId { get; set; }

    }
}
