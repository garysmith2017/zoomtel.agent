

namespace Zoomtel.Persist.Query
{
    /// <summary>
    /// 排序规则
    /// </summary>
    public enum SortType
    {
        /// <summary>
        /// 升序
        /// </summary>
        Asc,
        /// <summary>
        /// 降序
        /// </summary>
        Desc
    }
    /// <summary>
    /// 查询排序模型
    /// </summary>
    public class QuerySortModel
    {
        /// <summary>
        /// 字段
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 排序类型
        /// </summary>
        public SortType Type { get; set; }
    }
}
