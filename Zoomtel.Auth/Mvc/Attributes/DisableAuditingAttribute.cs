using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Auth.Mvc.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
   public class DisableAuditingAttribute : Attribute
    {
    }
}
