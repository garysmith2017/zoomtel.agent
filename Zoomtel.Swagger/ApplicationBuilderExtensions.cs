using System;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;

namespace Zoomtel.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 自定义Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI V1");

            });

            return app;
        }
    }
}
