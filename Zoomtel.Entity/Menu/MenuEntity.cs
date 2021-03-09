using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.Menu
{
    [Table("T_SYS_MENUS")]
   public class MenuEntity:EntityBaseWithMdInfo,BaseEntity
    {
        [Key]
      
        public string Id { get; set; }


        /// <summary>
        /// 父级ID
        /// </summary>
        public int Fid { get; set; }

        [MaxLength(150)]
        /// <summary>
        /// 菜单编码
        /// </summary>
        public string Code { get; set; }

        [MaxLength(150)]
        /// <summary>
        /// 模块编码
        /// </summary>
        public string ModuleCode { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }


        /// <summary>
        /// 排序
        /// </summary>
        public int Seq { get; set; }
        
        [MaxLength(20)]
        /// <summary>
        /// 打开方式
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 菜单等级
        /// </summary>
        //public int Level { get; set; }
         
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// 是否常用
        /// </summary>
        public bool Often { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Url { get; set; }
    }
}
