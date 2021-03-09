using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.Role
{
    /// <summary>
    /// 角色实体类
    /// </summary>
    [Table("T_SYS_ROLES")]
   public class RoleEntity:EntityBaseWithMdInfo, BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色启用状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 角色说明
        /// </summary>
        public string Remark { get; set; }
    }
}
