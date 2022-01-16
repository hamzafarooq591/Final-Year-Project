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

    public static class PurchaseOrderMapper
    {
        public static PurchaseOrder ToEntity(this PurchaseOrderBindingModel model, int userId, PurchaseOrder original = null)
        {
            bool flag = original != null;
            PurchaseOrder company = flag ? model.Map<PurchaseOrderBindingModel, PurchaseOrder>(original) : model.Map<PurchaseOrderBindingModel, PurchaseOrder>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<PurchaseOrder>(userId);
            }
            return company.MapLastModifiedFields<PurchaseOrder>(userId);
        }
        public static NashPagedList<PurchaseOrderViewModel> ToViewModel(this IPagedList<PurchaseOrder> models)
        {
            List<PurchaseOrderViewModel> viewModels = new List<PurchaseOrderViewModel>();
            models.ToList<PurchaseOrder>().ForEach(delegate (PurchaseOrder a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PurchaseOrderViewModel>(models.GetMetaData());
        }
        public static PurchaseOrderViewModel ToViewModel(this PurchaseOrder model)
        {
            return model.Map<PurchaseOrder, PurchaseOrderViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<PurchaseOrder, PurchaseOrderViewModel>()
                .ForMember(x => x.PartyName, y => y.MapFrom(x => x.Party.CustomerName))
                .ForMember(x => x.ItemName, y => y.MapFrom(x => x.Item.ItemName))
                .ForMember(x => x.PurchaseOrderId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<PurchaseOrderViewModel>(model);

        }
    }
}

