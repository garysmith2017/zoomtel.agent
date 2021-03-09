using EFCoreRepository.DbContexts;
using EFCoreRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity.BaseType;
using Zoomtel.Persist.BaseType.Models;

namespace Zoomtel.Persist.BaseType
{
   public class BaseTypeRepository:RepositoryAb<BaseTypeInfoEntity>
    {

        public BaseTypeRepository(DefaultDbContext context) : base(context)
        {


        }
        public async Task<List<BaseTypeInfoEntity>> QueryByCode(string Code)
        {

            var query = dbSet.AsQueryable();
            if (!Code.IsNull())
            {
                query = query.Where(a => a.TypeCode.Equals(Code));
            }
            return query.ToList();

        }
        //public async Task<List<BaseTypeInfoEntity>> QueryByCode(BaseTypeQueryModel model)
        //{

        //    var query = dbSet.AsQueryable();
        //    if (!model.Code.IsNull())
        //    {
        //        query = query.Where(a => a.TypeCode.Equals(model.Code));
        //    }
        //    return query.ToList();

        //}
    }
}
