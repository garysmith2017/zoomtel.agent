using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity;
using Zoomtel.Entity.AuditInfo;
using Zoomtel.Persist;
using Zoomtel.Persist.AuditInfo;
using Zoomtel.Persist.AuditInfo.Models;

namespace Zoomtel.Service.AuditInfo
{
    public class AuditInfoService 
    {
        private AuditInfoRepository _repository;
        public AuditInfoService(AuditInfoRepository repository)
        {
            _repository = repository;

        }

        public async Task<IResultModel> Add(AuditInfoEntity info)
        {
            if (info == null)
            {
                return ResultModel.Failed();
            }

            int result= await _repository.InsertAsync(info);
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            if (result > 0)
            {
                return  ResultModel.Success();

            }
            else
            {
                return ResultModel.Failed();

            }
        }

        public async Task<IResultModel<int>> DeleteList(List<Guid> ids)
        {
            var result = new ResultModel<int>();
            int i = 0;
            foreach (Guid id in ids)
            {
                i = i +await _repository.DeleteAsync(id);

            }
            return result.Success(i);
        }

        public async Task<IResultModel<QueryResultModel<AuditInfoEntity>>> Query(AuditInfoQueryModel model)
        {
            var result = new ResultModel<QueryResultModel<AuditInfoEntity>>();

            var data = await _repository.Query(model);

            return result.Success(data);

        }
    }
}
