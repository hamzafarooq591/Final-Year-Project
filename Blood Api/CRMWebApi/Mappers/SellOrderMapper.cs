namespace NashWebApi.Mappers
{
    using AutoMapper;
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class SellOrderMapper
    {
        public static SellOrder ToEntity(this SellOrderBindingModel model, int userId, SellOrder original = null)
        {
            bool flag = original != null;
            SellOrder company = flag ? model.Map<SellOrderBindingModel, SellOrder>(original) : model.Map<SellOrderBindingModel, SellOrder>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<SellOrder>(userId);
            }
            return company.MapLastModifiedFields<SellOrder>(userId);
        }
        public static NashPagedList<SellOrderViewModel> ToViewModel(this IPagedList<SellOrder> models)
        {
            List<SellOrderViewModel> viewModels = new List<SellOrderViewModel>();
            models.ToList<SellOrder>().ForEach(delegate (SellOrder a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<SellOrderViewModel>(models.GetMetaData());
        }
        public static SellOrderViewModel ToViewModel(this SellOrder model)
        {
            return model.Map<SellOrder, SellOrderViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<SellOrder, SellOrderViewModel>()
                .ForMember(x => x.PartyName, y => y.MapFrom(x => x.Party.CustomerName))
                .ForMember(x => x.ItemName, y => y.MapFrom(x => x.Item.ItemName))
                .ForMember(x => x.SellOrderId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<SellOrderViewModel>(model);

        }
    }
}

