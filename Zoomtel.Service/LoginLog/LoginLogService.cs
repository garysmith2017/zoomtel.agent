using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity.LoginLog;
using Zoomtel.Persist.LoginInfo;
using Zoomtel.Persist.LoginLog.Models;

namespace Zoomtel.Service.LoginLog
{
   public class LoginLogService
    {
        private LoginLogRepository _repository;
        public LoginLogService(LoginLogRepository repository)
        {
            _repository = repository;

        }

        public async Task<IResultModel> Add(LoginLogEntity info)
        {
            if (info == null)
            {
                return ResultModel.Failed();
            }

            info.Id = _repository.GetSeq("S_SYS_LOGINLOG").ToString();
            int result = await _repository.InsertAsync(info);
            return ResultModel.Success(result);
        }

        public async Task<IResultModel<QueryResultModel<LoginLogEntity>>> Query(LoginLogQueryModel model)
        {
            var result = new ResultModel<QueryResultModel<LoginLogEntity>>();

            var data = await _repository.Query(model);

            return result.Success(data);

        }


        public async Task<IResultModel> Delete(string id)
        {
            var result = await _repository.DeleteAsync(id);
            if (result > 0)
            {
                return ResultModel.Success();

            }
            else
            {
                return ResultModel.Failed();

            }
        }

        public async Task<IResultModel<int>> DeleteList(List<string> ids)
        {
            var result = new ResultModel<int>();
            int i = 0;
            foreach (string id in ids)
            {
                i = i + await _repository.DeleteAsync(id);

            }
            return result.Success(i);
        }

    }
}
