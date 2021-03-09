using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Persist.Account.Models
{
  public  class AccountQueryModel : Query.QueryModel
    {
        public bool? status { get; set; }
        public string keyword { get; set; }

    }
}
