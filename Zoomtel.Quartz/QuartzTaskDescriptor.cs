using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Quartz.Abstractions
{
  public  class QuartzTaskDescriptor
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类名称
        /// </summary>
        public string Class { get; set; }
    }
}
