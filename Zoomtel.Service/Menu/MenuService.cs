using System;
using System.Collections.Generic;
using System.Text;
using Zoomtel.Entity;
using Zoomtel.Persist;
using System.Linq;
using Zoomtel.Service.Menu.ViewModels;
using AutoMapper;
using System.Threading.Tasks;
using Zoomtel.Entity.Menu;
using Zoomtel.Persist.Menu;

namespace Zoomtel.Service.Menu
{
  public  class MenuService
    {
        private readonly MenuRepository _repository;
        private readonly IMapper _mapper;

        public MenuService(MenuRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }


        public async Task<IResultModel<QueryResultModel<MenuEntity>>> Query(MenuQueryModel model)
        {
            var result = new ResultModel<QueryResultModel<MenuEntity>>();

            var data = await _repository.Query(model);

            return result.Success(data);

        }

        private void getSonMenus(MenuTreeModel model)
        {
            var list = _repository.FindList(a => a.Fid == model.Id);
          
            if (list != null && list.Count() > 0)
            {
                var mapperList = _mapper.Map<IEnumerable<MenuEntity>, IEnumerable<MenuTreeModel>>(list);


                foreach (var sonmodel in mapperList)
                {
                    getSonMenus(sonmodel);

                }
                model.children = mapperList;
            }
        }

        public IEnumerable<MenuTreeModel> getMainMenu()
        {
            var list = _repository.FindList(a => a.Fid == 0);
            if (list != null && list.Count() > 0)
            {
                var mapperList = _mapper.Map<IEnumerable<MenuEntity>, IEnumerable<MenuTreeModel>>(list);

                foreach (var sonmodel in mapperList)
                {
                    getSonMenus(sonmodel);
                }
                return mapperList;
            }
            return null;
        }

        private void LoadTreeLoop(TreeResultModel<int, MenuEntity> ParentTree,IEnumerable<MenuEntity> Menus)
        {
            var list = Menus.Where(a => a.Fid == ParentTree.Id).ToList();
            if (list.Count > 0)
            {
                ParentTree.Children = new List<TreeResultModel<int, MenuEntity>>();
            }
            //模块
            foreach (var item in list)
            {
                var itemNode = new TreeResultModel<int, MenuEntity>
                {
                    Id = item.Id,
                    Text = item.MenuName,
                    IconCls=item.Icon,
                    Item = item
                };
                LoadTreeLoop(itemNode, Menus);

                itemNode.Path.AddRange(ParentTree.Path);
                itemNode.Path.Add(item.MenuName);

                ParentTree.Children.Add(itemNode);
            }
           

        }
        /// <summary>
        /// 加载权限树
        /// </summary>
        /// <returns></returns>
        public async Task<List<TreeResultModel<int, MenuEntity>>> LoadTree()
        {
            List<TreeResultModel<int, MenuEntity>> list = new List<TreeResultModel<int, MenuEntity>>();
            var menus = _repository.FindList().OrderByDescending(a=>a.Seq).ToList();
            var parentMenus = menus.Where(a => a.Fid == 0).ToList();
            foreach(var item in parentMenus)
            {
                var _tree = new TreeResultModel<int, MenuEntity>
                {
                    Id = item.Id,
                    Text = item.MenuName,
                    IconCls = item.Icon,
                    Item =item
                };
                _tree.Path.Add(_tree.Text);
                LoadTreeLoop(_tree, menus);

                list.Add(_tree);

            }

            return list;
        }

        /// <summary>
        /// 加载用户权限树
        /// </summary>
        /// <returns></returns>
        public async Task<List<TreeResultModel<int, MenuEntity>>> LoadUserTree()
        {

            List<TreeResultModel<int, MenuEntity>> list = new List<TreeResultModel<int, MenuEntity>>();
            var menus = await _repository.GetListByUser();
            menus= menus.OrderByDescending(a => a.Seq).ToList();
            var parentMenus = menus.Where(a => a.Fid == 0).ToList();
            foreach (var item in parentMenus)
            {
                var _tree = new TreeResultModel<int, MenuEntity>
                {
                    Id = item.Id,
                    Text = item.MenuName,
                    IconCls=item.Icon,
                    Item = new MenuEntity()
                };
                _tree.Path.Add(_tree.Text);
                LoadTreeLoop(_tree, menus);

                list.Add(_tree);

            }

            return list;
        }

        public async Task<IResultModel<int>> Add(MenuEntity model)
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
        

        public async Task<IResultModel<int>> Update(MenuEntity model)
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

        public async Task<IResultModel> View(int id)
        {
            var result = new ResultModel<MenuEntity>();
            var model = await _repository.FindEntityAsync(id);
            return result.Success(model);
        }

        public async Task<IResultModel<int>> Delete(int id)
        {
            var result = new ResultModel<int>();
          if(  _repository.Exists(a => a.Fid == id))
            {
                return result.Failed("存在子菜单，无法删除！");

            }

            int i =await _repository.DeleteAsync(id);
            return result.Success( i);
        }
        public async Task<IResultModel> ChangeOften(int id, bool often)
        {

            var model = _repository.FindEntity(id);
            model.Often = often;
            int i = await _repository.UpdateAsync(model);
            if (i > 0)
            {
                return ResultModel.Success();
            }
            else
            {
                return ResultModel.Failed();
            }
        }
        public async Task<IResultModel> ChangeVisible(int id, bool visible)
        {

            var model = _repository.FindEntity(id);
            model.Visible = visible;
         int i=await   _repository.UpdateAsync(model);
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
