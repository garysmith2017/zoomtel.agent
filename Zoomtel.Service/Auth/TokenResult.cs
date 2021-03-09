using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Service.Auth
{
    public class UserTokenResult
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public DateTime expires_at { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
    }
}
