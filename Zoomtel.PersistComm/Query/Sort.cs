﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zoomtel.Persist.Query
{
    /// <summary>
    /// 排序规则
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderBy { get; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public SortType Type { get; }

        public Sort(string orderBy, SortType type = SortType.Asc)
        {
            OrderBy = orderBy;
            Type = type;
        }
    }
}
