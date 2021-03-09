using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Persist.Menu
{
   public class MenuQueryModel : Query.QueryModel
    {
        public string MenuName { get; set; }
        public string Url { get; set; }

        public string Code { get; set; }
    }
}
