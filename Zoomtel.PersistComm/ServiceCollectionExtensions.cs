using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
namespace Zoomtel.Persist
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// 添加实体仓储
        /// </summary>
        /// <param name="services"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public static IServiceCollection AddModuleRepository(this IServiceCollection services, string[] files)
        {
            foreach (var filename in files)
            {
                AddModuleRepository(services, filename);

            }


            return services;
        }

        /// <summary>
        /// 添加应用服务
        /// </summary>
        private static void AddModuleRepository(this IServiceCollection services, string filename)
        {
            
            var assembly = System.Reflection.Assembly.Load(filename);
            if (assembly == null)
                return;

            var types = assembly.GetTypes();
            var interfaces = types.Where(t => t.FullName != null && t.FullName.EndsWith("Repository", StringComparison.OrdinalIgnoreCase));
            foreach (var serviceType in interfaces)
            {

                services.AddScoped(serviceType);

                //var implementationType = types.FirstOrDefault(m => m != serviceType && serviceType.IsAssignableFrom(m));
                //if (implementationType != null)
                //{
                //    services.Add(new ServiceDescriptor(serviceType, implementationType, ServiceLifetime.Scoped));
                //}
            }
        }
    }
}
