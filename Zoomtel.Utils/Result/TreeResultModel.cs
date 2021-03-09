using System.Collections.Generic;

namespace Zoomtel
{

    public interface ITreeResultModel<TKey,T> where T : class, new()
    {
        /// <summary>
        /// 编号
        /// </summary>
         TKey Id { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
         string Text { get; set; }
        /// <summary>
        /// 值(可选)
        /// </summary>
         object Value { get; set; }

        /// <summary>
        /// 图标(可选)
        /// </summary>
         string Icon { get; set; }

        /// <summary>
        /// 路径列表
        /// </summary>
        List<string> Path { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
         List<T> Children { get; set; }
    }

    /// <summary>
    /// 树形结构返回模型
    /// </summary>
    /// <typeparam name="TKey">编号类型</typeparam>
    /// <typeparam name="T"></typeparam>
    public class TreeResultModel<TKey, T> where T : class, new()
    {
        /// <summary>
        /// 编号
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 值(可选)
        /// </summary>
        public object Value { get; set; }


        /// <summary>
        /// 图标(可选)
        /// </summary>
        public string IconCls { get; set; }

        /// <summary>
        /// 数据项
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// 路径列表
        /// </summary>
        public List<string> Path { get; } = new List<string>();

        /// <summary>
        /// 子节点
        /// </summary>
        public List<TreeResultModel<TKey, T>> Children { get; set; }
    }

    /// <summary>
    /// 树形结构返回模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeResultModel<T> : TreeResultModel<int, T> where T : class, new()
    {
        /// <summary>
        /// 子节点
        /// </summary>
        public new List<TreeResultModel<T>> Children { get; set; } = new List<TreeResultModel<T>>();
    }
}
