using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zoomtel.Persist.Query;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Zoomtel;

namespace EFCoreRepository.Extensions
{
   public static class IQueryableExtensions
    {
        #region 分页查询方法

        public async static Task<QueryResultModel<TResult>> PaginationGetResult<TResult>(this IQueryable<TResult> QueryBody, Paging paging = null)
        {
            if (paging == null)
                paging = new Paging();

            //QueryBody.or(paging.OrderBy);

            paging.TotalCount = await QueryBody.CountAsync();

            var list = QueryBody.Skip(paging.Skip).Take(paging.Size).ToList();

            //var list = await QueryBody.ToListAsync();

            List<TResult> list2 = new List<TResult>(list);
            QueryResultModel<TResult> result = new QueryResultModel<TResult>();
            result.Total = paging.TotalCount;
            result.Rows = list2;
            return result;
        }


        public async static Task< IList< TResult>> Pagination<TResult>(this IQueryable<TResult> QueryBody, Paging paging = null)
        {
            if (paging == null)
                paging = new Paging();

            //QueryBody.or(paging.OrderBy);

            paging.TotalCount =await QueryBody.CountAsync();

            QueryBody.Skip(paging.Skip).Take(paging.Size);

            var list = await QueryBody.ToListAsync();

            List<TResult> list2 = new List<TResult>(list);
            return list2;
        }
        #endregion

    }
}
