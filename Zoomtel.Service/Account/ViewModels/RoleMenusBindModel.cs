using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Service.Account.ViewModels
{
  public  class RolePermissionBindModel
    {
        public int RoleId { get; set; }

        public List<string> Permissions { get; set; }
    }
}
