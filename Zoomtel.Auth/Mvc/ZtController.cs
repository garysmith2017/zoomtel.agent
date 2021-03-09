using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoomtel.Auth.Mvc.Attributes;

namespace Zoomtel.Auth.Mvc
{
    [Route("[area]/[controller]/[action]")]
    [ApiController]
    [PermissionValidate]
    [Auditing]
    public abstract class ZtController: Controller
    {
        //public ZtController()
        //{

        //}
      


    }
}
