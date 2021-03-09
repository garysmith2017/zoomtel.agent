using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zoomtel.AutoMapper;
using Zoomtel.Entity.Menu;
using Zoomtel.Service.Menu.ViewModels;

namespace Zoomtel.Service.Menu
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            //cfg.CreateMap<MenuTreeModel, MenuEntity>();

            cfg.CreateMap<MenuEntity, MenuTreeModel>();

            //cfg.CreateMap<MenuTreeModel, MenuEntity>();

            //cfg.CreateMap<AccountSyncModel, AccountEntity>().ForMember(m => m.Roles, opt => opt.Ignore());

            //cfg.CreateMap<AccountEntity, AccountUpdateModel>();
            //cfg.CreateMap<AccountUpdateModel, AccountEntity>().ForMember(m => m.Roles, opt => opt.Ignore());
        }
    }
}
