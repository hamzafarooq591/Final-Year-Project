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

    public static class WPQuantityMapper
    {
        public static WPQuantity ToEntity(this WPQuantityBindingModel model, int userId, WPQuantity original = null)
        {
            bool flag = original != null;
            WPQuantity company = flag ? model.Map<WPQuantityBindingModel, WPQuantity>(original) : model.Map<WPQuantityBindingModel, WPQuantity>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<WPQuantity>(userId);
            }
            return company.MapLastModifiedFields<WPQuantity>(userId);
        }
        public static NashPagedList<WPQuantityViewModel> ToViewModel(this IPagedList<WPQuantity> models)
        {
            List<WPQuantityViewModel> viewModels = new List<WPQuantityViewModel>();
            models.ToList<WPQuantity>().ForEach(delegate (WPQuantity a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<WPQuantityViewModel>(models.GetMetaData());
        }
        public static WPQuantityViewModel ToViewModel(this WPQuantity model)
        {
            return model.Map<WPQuantity, WPQuantityViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<WPQuantity, WPQuantityViewModel>()
                .ForMember(x => x.WarehouseId, y => y.MapFrom(x => x.Warehouse.Id))
                .ForMember(x => x.WarehouseName, y => y.MapFrom(x => x.Warehouse.WarehouseName))
                .ForMember(x => x.WPQuantityId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.ProductName));
            }).MapAuditableFields<WPQuantityViewModel>(model);

        }
    }
}

