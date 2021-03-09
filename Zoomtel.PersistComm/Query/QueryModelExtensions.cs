using System.Linq;

namespace Zoomtel.Persist.Query
{

   

    public static class QueryModelExtensions
    {
        /// <summary>
        /// 获取Paging分页类
        /// </summary>
        public static Paging Paging(this QueryModel model)
        {
            var paging = new Paging(model.PageModel.page, model.PageModel.rows);
            if (model.PageModel.Sort != null && model.PageModel.Sort.Any())
            {
                foreach (var sort in model.PageModel.Sort)
                {
                    paging.OrderBy.Add(new Sort(sort.Field, sort.Type));
                }
            }

            return paging;
        }
    }
}
