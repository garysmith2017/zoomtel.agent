using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zoomtel.Auth.Mvc;
using Zoomtel.Auth.Mvc.Attributes;
using Zoomtel.Persist.Query;

namespace Zoomtel.Web
{
    [Area("admin")]
    public abstract class ModuleController : ZtController
    {
        ////[HttpGet]
        //protected QueryPagingModel getQueryPageModel()
        //{
        //    QueryPagingModel model = new QueryPagingModel();
        //    if (HttpContext.Request.Method == "POST"&&HttpContext.Request.Form!=null)
        //    {
        //        if (HttpContext.Request.Form.Keys.Contains("page"))
        //        {
        //            model.page = int.Parse(HttpContext.Request.Form["page"][0]);
        //        }
        //        if (HttpContext.Request.Form.Keys.Contains("rows"))
        //        {
        //            model.rows = int.Parse(HttpContext.Request.Form["rows"][0]);
        //        }
        //    }
        //    else
        //    {
        //        if (HttpContext.Request.Query.Keys.Contains("page") && HttpContext.Request.Query != null)
        //        {
        //            model.page = int.Parse(HttpContext.Request.Query["page"][0]);
        //        }
        //        if (HttpContext.Request.Query.Keys.Contains("rows"))
        //        {
        //            model.rows = int.Parse(HttpContext.Request.Query["rows"][0]);
        //        }

        //    }
        //    return model;

        //}
    }
    
}