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

    public static class SaleDeliveryMapper
    {
        public static SaleDelivery ToEntity(this SaleDeliveryBindingModel model, int userId, SaleDelivery original = null)
        {
            bool flag = original != null;
            SaleDelivery company = flag ? model.Map<SaleDeliveryBindingModel, SaleDelivery>(original) : model.Map<SaleDeliveryBindingModel, SaleDelivery>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<SaleDelivery>(userId);
            }
            return company.MapLastModifiedFields<SaleDelivery>(userId);
        }
        public static NashPagedList<SaleDeliveryViewModel> ToViewModel(this IPagedList<SaleDelivery> models)
        {
            List<SaleDeliveryViewModel> viewModels = new List<SaleDeliveryViewModel>();
            models.ToList<SaleDelivery>().ForEach(delegate (SaleDelivery a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<SaleDeliveryViewModel>(models.GetMetaData());
        }
        public static SaleDeliveryViewModel ToViewModel(this SaleDelivery model)
        {
            return model.Map<SaleDelivery, SaleDeliveryViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<SaleDelivery, SaleDeliveryViewModel>()
                .ForMember(x => x.TransporterName, y => y.MapFrom(x => x.Transporter.CustomerName))
                .ForMember(x => x.PurchaseOrderName, y => y.MapFrom(x => x.PurchaseOrder.Id))
                .ForMember(x => x.SellOrderName, y => y.MapFrom(x => x.SellOrder.Id))
                .ForMember(x => x.SaleDeliveryId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<SaleDeliveryViewModel>(model);

        }
    }
}

