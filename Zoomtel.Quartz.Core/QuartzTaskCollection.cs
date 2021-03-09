using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zoomtel.Quartz.Abstractions;
using Zoomtel.Utils.Abstracts;
using Zoomtel.Utils.Helpers;

namespace Zoomtel.Quartz.Core
{
   public class QuartzTaskCollection: CollectionAbstract<QuartzTaskDescriptor>
    {

        public void LoadAll()
        {
            var assemblies = AssemblyHelper.Load();
            foreach (var assembly in assemblies)
            {
                if (assembly != null)
                {
                    var taskTypes = assembly.GetTypes().Where(m => typeof(ITask).IsAssignableFrom(m));
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
                            Add(taskDescriptor);//把任务描述添加到集合
                                                //descriptor.Tasks.Add(taskDescriptor);
                        }

                    }
                }
            }
        }

    }
}
