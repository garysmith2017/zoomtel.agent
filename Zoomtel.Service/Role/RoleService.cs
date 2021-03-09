using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity.Account;
using Zoomtel.Entity.Role;
using Zoomtel.Persist.Role;
using Zoomtel.Persist.Role.Models;
using Zoomtel.Service.Account.ViewModels;
using Zoomtel.Service.Role;

namespace Zoomtel.Service.Role
{
    public class RoleService 
    {
        private RoleMenuRepository _roleMenuRepository;

        private RoleRepository _repository;
        private RolePermissionRepository _rolePermissionRepository;
        public RoleService(RoleRepository roleRepository, RolePermissionRepository rolePermissionRepository, RoleMenuRepository roleMenuRepository)
        {
            _repository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _roleMenuRepository = roleMenuRepository;

        }

        public async Task<IResultModel<int>> Add(RoleEntity model)
        {
            var result = new ResultModel<int>();

            int i = _repository.Insert(model);
            if (i > 0)
            {

                return result.Success(i);
            }
            else
            {
                return result.Failed();

            }
        }

        public async Task<IResultModel<int>> Delete(int id)
        {
            var result = new ResultModel<int>();
            int i = await _repository.DeleteAsync(id);
            if (i > 0)
            {

                return result.Success(i);
            }
            else
            {
                return result.Failed();

            }
        }

        public async Task<IResultModel<int>> Update(RoleEntity model)
        {
            var result = new ResultModel<int>();

            int i = _repository.Update(model);
            if (i > 0)
            {

                return result.Success(i);
            }
            else
            {
                return result.Failed();

            }
        }

        public async Task<IResultModel> Edit(int id)
        {
            var result = new ResultModel<RoleEntity>();

            var model = await _repository.FindEntityAsync(id);
            return result.Success(model);
        }

        public async Task<IResultModel<QueryResultModel<RoleEntity>>> Query(RuleQueryModel model)
        {
            var result = new ResultModel<QueryResultModel<RoleEntity>>();

            var data = await _repository.Query(model);

            return result.Success(data);
        }

        public async Task<IResultModel<int>> DeleteList(List<int> ids)
        {
            var result = new ResultModel<int>();
            int i = 0;
            foreach (int id in ids)
            {
                i = i + _repository.Delete(id);

            }
            return result.Success(i);

        }

        public async Task<IList<OptionResultModel>> Select()
        {

            var all = await _repository.FindListAsync();
            var list = all.Select(m => new OptionResultModel
            {
                Label = m.RoleName,
                Value = m.Id
            }).ToList();

            return list;
        }

        public async Task<IResultModel> BindPermissions(RolePermissionBindModel model)
        {
            _rolePermissionRepository.BeginTrans();
            var result = await _rolePermissionRepository.DeleteByRole(model.RoleId);
            if (result >= 0)
            {
                if (model.Permissions != null && model.Permissions.Any())
                {
                    var list = model.Permissions.Select(m => new RolePermissionEntity
                    {
                        RoleId = model.RoleId,
                        PermissionCode = m
                    }).ToList();

                    await _rolePermissionRepository.InsertAsync(list);
                }

                _rolePermissionRepository.Commit();
                //todo 这里是做什么的需要搞清楚
                //await ClearAccountPermissionCache(model.RoleId);
                return ResultModel.Success();
            }
            return ResultModel.Failed();
        }

        public async Task<IResultModel> QueryPermissions(int roleId)
        {

            var list = await _rolePermissionRepository.QueryByRole(roleId);
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> BindMenus(RoleMenusBindModel model)
        {
            _rolePermissionRepository.BeginTrans();
            var result = await _roleMenuRepository.DeleteByRole(model.RoleId);
            if (result >= 0)
            {
                if (model.Menus != null && model.Menus.Any())
                {
                    var list = model.Menus.Select(m => new RoleMenuEntity
                    {
                        RoleId = model.RoleId,
                        MenuId = m
                    }).ToList();

                    await _roleMenuRepository.InsertAsync(list);
                }

                _rolePermissionRepository.Commit();
                //todo 这里是做什么的需要搞清楚
                //await ClearAccountPermissionCache(model.RoleId);
                return ResultModel.Success();
            }
            return ResultModel.Failed();
        }

        public async Task<IResultModel> QueryMenus(int roleId)
        {
            var list = await _roleMenuRepository.QueryByRole(roleId);
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> QueryByUid(Guid uid)
        {
            var list = await _rolePermissionRepository.QueryByAccount(uid);
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> StatusChange(int id, bool status)
        {


        var entity=    _repository.FindEntity(id);
            entity.Status = status;
         int i=  await  _repository.UpdateAsync(entity);
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