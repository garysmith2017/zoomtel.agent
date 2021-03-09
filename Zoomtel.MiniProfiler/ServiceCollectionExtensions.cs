using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.MiniProfiler
{
    public static class ServiceCollectionExtensions
    {
       
        public static IServiceCollection AddCustomMiniProfiler(this IServiceCollection services)
        {
            services.AddMiniProfiler().AddEntityFramework();
            return services;
        }
    }
}
