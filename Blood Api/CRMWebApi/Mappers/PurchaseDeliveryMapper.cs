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

    public static class PurchaseDeliveryMapper
    {
        public static PurchaseDelivery ToEntity(this PurchaseDeliveryBindingModel model, int userId, PurchaseDelivery original = null)
        {
            bool flag = original != null;
            PurchaseDelivery company = flag ? model.Map<PurchaseDeliveryBindingModel, PurchaseDelivery>(original) : model.Map<PurchaseDeliveryBindingModel, PurchaseDelivery>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<PurchaseDelivery>(userId);
            }
            return company.MapLastModifiedFields<PurchaseDelivery>(userId);
        }
        public static NashPagedList<PurchaseDeliveryViewModel> ToViewModel(this IPagedList<PurchaseDelivery> models)
        {
            List<PurchaseDeliveryViewModel> viewModels = new List<PurchaseDeliveryViewModel>();
            models.ToList<PurchaseDelivery>().ForEach(delegate (PurchaseDelivery a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PurchaseDeliveryViewModel>(models.GetMetaData());
        }
       
        public static PurchaseDeliveryViewModel ToViewModel(this PurchaseDelivery model)
        {
            return model.Map<PurchaseDelivery, PurchaseDeliveryViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<PurchaseDelivery, PurchaseDeliveryViewModel>()
                .ForMember(x => x.PurchaseOrderName, y => y.MapFrom(x => x.PurchaseOrder.Id))
                .ForMember(x => x.SaleDeliveryName, y => y.MapFrom(x => x.SaleDelivery.Id))
                .ForMember(x => x.PurchaseDeliveryId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<PurchaseDeliveryViewModel>(model);

        }
    }
}

