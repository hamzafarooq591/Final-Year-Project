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

    public static class ProductWarrantyMapper
    {
        public static ProductWarranty ToEntity(this ProductWarrantyBindingModel model, int userId, ProductWarranty original = null)
        {
            bool flag = original != null;
            ProductWarranty company = flag ? model.Map<ProductWarrantyBindingModel, ProductWarranty>(original) : model.Map<ProductWarrantyBindingModel, ProductWarranty>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<ProductWarranty>(userId);
            }
            return company.MapLastModifiedFields<ProductWarranty>(userId);
        }
        public static NashPagedList<ProductWarrantyViewModel> ToViewModel(this IPagedList<ProductWarranty> models)
        {
            List<ProductWarrantyViewModel> viewModels = new List<ProductWarrantyViewModel>();
            models.ToList<ProductWarranty>().ForEach(delegate (ProductWarranty a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ProductWarrantyViewModel>(models.GetMetaData());
        }
        public static ProductWarrantyViewModel ToViewModel(this ProductWarranty model)
        {
            return model.Map<ProductWarranty, ProductWarrantyViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<ProductWarranty, ProductWarrantyViewModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.ProductName))
                .ForMember(x => x.WarrantyModeId, y => y.MapFrom(x => x.WarrantyMode.Id))
                .ForMember(x => x.WarrantyModeTitle, y => y.MapFrom(x => x.WarrantyMode.WarrantyModePeriodInDays))
                .ForMember(x => x.ProductWarrantyId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<ProductWarrantyViewModel>(model);

        }
    }
}

