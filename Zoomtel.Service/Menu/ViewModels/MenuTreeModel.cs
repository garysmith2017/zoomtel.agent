using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Service.Menu.ViewModels
{
   public class MenuTreeModel
    {

        public int Id { get; set; }

        public string Code { get; set; }

        public string MenuName { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }


        /// <summary>
        /// 排序
        /// </summary>
        public int Seq { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url { get; set; }


        //public string state { get; set; } = "closed";

        /// <summary>
        /// 下级菜单
        /// </summary>
        public IEnumerable<MenuTreeModel> children { get; set; }

    }
}
