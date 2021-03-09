using System.Collections.Generic;

namespace Zoomtel.Persist.Query
{
    /// <summary>
    /// 查询分页模型
    /// </summary>
    public class QueryPagingModel
    {
        /// <summary>
        /// 当前页 适应easyui
        /// </summary>
        //public int Index { get; set; } = 1;
        public int page { get; set; } = 1;

        /// <summary>
        /// 页大小 适应easyui
        /// </summary>
        public int rows { get; set; } = 15;

        /// <summary>
        /// 排序字段
        /// </summary>
        public List<QuerySortModel> Sort { get; set; }
    }
}
