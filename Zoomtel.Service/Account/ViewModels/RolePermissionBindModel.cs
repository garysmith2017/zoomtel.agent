using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Service.Account.ViewModels
{
  public  class RoleMenusBindModel
    {
        public int RoleId { get; set; }

        public List<int> Menus { get; set; }
    }
}
