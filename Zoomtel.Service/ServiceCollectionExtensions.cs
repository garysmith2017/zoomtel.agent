using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Zoomtel.Service
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// 添加模块的自定义服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public static IServiceCollection AddModuleServices(this IServiceCollection services,  string[] files)
        {
            foreach(var filename in files)
            {
                AddApplicationServices(services, filename);

            }
          

            return services;
        }

        /// <summary>
        /// 添加应用服务
        /// </summary>
        private static void AddApplicationServices(this IServiceCollection services, string filename)
        {
            var assembly = System.Reflection.Assembly.Load(filename);
            if (assembly == null)
                return;

            var types = assembly.GetTypes();

            var interfaces = types.Where(t => t.FullName != null  && t.FullName.EndsWith("Service", StringComparison.OrdinalIgnoreCase));
            foreach (var serviceType in interfaces)
            {
                services.AddScoped(serviceType);

                //var implementationType = types.FirstOrDefault(m => m != serviceType && serviceType.IsAssignableFrom(m));
                //if (implementationType != null)
                //{
                //    services.Add(new ServiceDescriptor(serviceType, implementationType, ServiceLifetime.Scoped));
                //}
            }


            //var interfaces = types.Where(t => t.FullName != null && t.IsInterface && t.FullName.EndsWith("Service", StringComparison.OrdinalIgnoreCase));
            //foreach (var serviceType in interfaces)
            //{
            //    var implementationType = types.FirstOrDefault(m => m != serviceType && serviceType.IsAssignableFrom(m));
            //    if (implementationType != null)
            //    {
            //        services.Add(new ServiceDescriptor(serviceType, implementationType, ServiceLifetime.Scoped));
            //    }
            //}
        }
    }
}
