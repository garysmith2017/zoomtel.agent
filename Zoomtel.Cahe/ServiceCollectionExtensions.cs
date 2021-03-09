﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zoomtel.Utils.Helpers;
using System.Linq;
namespace Zoomtel.Cache
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="services"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration cfg)
        {
            var config = new CacheConfig();
            var section = cfg.GetSection("Cache");
            section?.Bind(config);

            services.AddSingleton(config);

            var assembly = AssemblyHelper.LoadByNameEndString($".Cache.{config.Provider.ToString()}");

            Check.NotNull(assembly, $"缓存实现程序集({config.Provider.ToString()})未找到");

            var handlerType = assembly.GetTypes().FirstOrDefault(m => typeof(ICacheHandler).IsAssignableFrom(m));
            if (handlerType != null)
            {
                services.AddSingleton(typeof(ICacheHandler), handlerType);
            }

            return services;
        }
    }
}
