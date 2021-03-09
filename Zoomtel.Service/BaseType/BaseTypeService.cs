using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity.BaseType;
using Zoomtel.Persist.BaseType;
using Zoomtel.Persist.BaseType.Models;
using System.Linq;
namespace Zoomtel.Service.BaseType
{
    public class BaseTypeService 
    {
        BaseTypeRepository _repository;

        public BaseTypeService(BaseTypeRepository repository) {

            _repository = repository;
        }

        public async Task<IList<OptionResultModel>> Select(string typeCode)
        {
            
            var result= await _repository.QueryByCode(typeCode);
            var list = result.Select(m => new OptionResultModel
            {
                Label = m.TypeContent,
                Data=m,
                Value = m.Id
            }).ToList();
            return list;
        }

    }
}
