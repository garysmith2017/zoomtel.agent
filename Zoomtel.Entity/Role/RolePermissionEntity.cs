using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.Role
{
    /// <summary>
    /// 权限角色关联表
    /// </summary>
    [Table("T_SYS_ROLEPERMISSION")]
    public  class RolePermissionEntity:BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 权限代码
        /// </summary>
        public string PermissionCode { get; set; }
    }
}
