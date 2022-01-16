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

    public static class ProductMapper
    {

        //public static NashRolesViewModel ToViewModel(this NashRole model)
        //{
        //    return model.Map<NashRole, NashRolesViewModel>(delegate (IMapperConfigurationExpression cfg) {
        //        cfg.CreateMap<NashRole, NashRolesViewModel>()
        //        .ForMember(x => x.NashRolesId, y => y.MapFrom(x => x.Id));
        //        }).MapAuditableFields<NashRolesViewModel>(model);
        //}
        public static Product ToEntity(this ProductBindingModel model, int userId, Product original = null)
        {
            bool flag = original != null;
            Product company = flag ? model.Map<ProductBindingModel, Product>(original) : model.Map<ProductBindingModel, Product>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Product>(userId);
            }
            return company.MapLastModifiedFields<Product>(userId);
        }
        public static NashPagedList<ProductViewModel> ToViewModel(this IPagedList<Product> models)
        {
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            models.ToList<Product>().ForEach(delegate (Product a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ProductViewModel>(models.GetMetaData());


        }
        public static ProductViewModel ToViewModel(this Product model)
        {
            return model.Map<Product, ProductViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.ManufacturerName, y => y.MapFrom(x => x.Manufacturer.ManufacturerName))
                .ForMember(x => x.CategoryName, y => y.MapFrom(x => x.Category.CategoryName))
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.WarrantyModeId, y => y.MapFrom(x => x.WarrantyMode.Id))
                .ForMember(x => x.WarrantyPeriod, y => y.MapFrom(x => x.WarrantyMode.WarrantyModePeriod))
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.ProductName));
            }).MapAuditableFields<ProductViewModel>(model);

        }
    }
}

