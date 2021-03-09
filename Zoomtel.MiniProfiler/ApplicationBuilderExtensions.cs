using Microsoft.AspNetCore.Builder;
using System;

namespace Zoomtel.MiniProfiler
{
    public static class ApplicationBuilderExtensions
    {
     
        public static IApplicationBuilder UseCustomMiniProfiler(this IApplicationBuilder app)
        {
            app.UseMiniProfiler();
            return app;

        }
    }
}
