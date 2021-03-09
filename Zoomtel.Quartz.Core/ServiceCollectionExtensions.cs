using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Zoomtel.Quartz.Abstractions;
using Zoomtel.Utils.Helpers;

namespace Zoomtel.Quartz.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void LoadAll(QuartzTaskCollection collect, IServiceCollection services)
        {
            var assemblies = AssemblyHelper.Load().Where(a=>a.FullName.Contains("Zoomtel"));
          
            foreach (var assembly in assemblies)
            {
                if (assembly != null)
                {
                    var taskTypes = assembly.GetTypes().Where(m => typeof(ITask).IsAssignableFrom(m)&&m!=typeof(ITask)&&m!=typeof(TaskAbstract));
                    foreach (var taskType in taskTypes)
                    {
                        //排除HttpTask
                        if (!taskType.Name.Equals("HttpTask"))
                        {
                            var taskDescriptor = new QuartzTaskDescriptor
                            {
                                Name = taskType.Name,
                                Class = $"{taskType.FullName}, {taskType.Assembly.GetName().Name}"
                            };

                            var descAttr = (DescriptionAttribute)Attribute.GetCustomAttribute(taskType, typeof(DescriptionAttribute));
                            if (descAttr != null && descAttr.Description.NotNull())
                            {
                                taskDescriptor.Name = descAttr.Description;
                            }
                          collect.Add(taskDescriptor);//把任务描述添加到集合
                            services.AddTransient(taskType); //注入任务类
                                                //descriptor.Tasks.Add(taskDescriptor);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 添加Quartz服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddQuartz(this IServiceCollection services)
        {

            QuartzTaskCollection collect = new QuartzTaskCollection();
            LoadAll(collect, services);

            //注入集合
            services.AddSingleton(collect);


            //注入日志
            services.TryAddTransient<ITaskLogger, TaskLogger>();

            //注入Quartz服务实例
            services.AddSingleton<IQuartzServer, QuartzServer>();
            return services;
        }
    }
}
