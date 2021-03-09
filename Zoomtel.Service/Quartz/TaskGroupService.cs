using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity.Quartz;
using Zoomtel.Persist.Quartz;
using Zoomtel.Persist.Quartz.Model;

namespace Zoomtel.Service.Quartz
{
    public class TaskGroupService 
    {
        TaskGroupRepository _repository;
        public TaskGroupService(TaskGroupRepository repository)
        {
            _repository = repository;

        }

        public async Task<IResultModel<Guid>> Add(TaskGroupEntity model)
        {
            var result = new ResultModel<Guid>();
            model.Id = Guid.NewGuid();
            int i =await _repository.InsertAsync(model);
            if (i > 0)
            {

                return result.Success(model.Id);
            }
            else
            {
                return result.Failed();

            }
        }

        public async Task<IResultModel> Delete(Guid id)
        {
            int result =await _repository.DeleteAsync(id);
            if (result > 0)
            {
                return ResultModel.Success();

            }
            else
            {
                return ResultModel.Failed();
            }
        }

        public async Task<IResultModel> Find(Guid id)
        {
            return ResultModel.Success( _repository.FindEntity(id));
        }

        public async Task<IResultModel<QueryResultModel<TaskGroupEntity>>> Query(TaskGroupQueryModel model)
        {
            var result = new ResultModel<QueryResultModel<TaskGroupEntity>>();

            var data = await _repository.Query(model);

            return result.Success(data);
        }

        public async Task<IResultModel> Update(TaskGroupEntity model)
        {
        

            int i =await _repository.UpdateAsync(model);
            if (i > 0)
            {

                return ResultModel.Success();
            }
            else
            {
                return ResultModel.Failed();

            }
        }
    }
}
