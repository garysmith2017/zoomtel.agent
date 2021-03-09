using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zoomtel.AutoMapper;
using Zoomtel.Entity.Account;
using Zoomtel.Service.Account.ViewModels;

namespace Zoomtel.Service.Account
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AccountAddModel, AccountEntity>().ForMember(m => m.Roles, opt => opt.Ignore());
            //cfg.CreateMap<AccountSyncModel, AccountEntity>().ForMember(m => m.Roles, opt => opt.Ignore());

            cfg.CreateMap<AccountEntity, AccountUpdateModel>();
            cfg.CreateMap<AccountUpdateModel, AccountEntity>().ForMember(m => m.Roles, opt => opt.Ignore());
        }
    }
}
