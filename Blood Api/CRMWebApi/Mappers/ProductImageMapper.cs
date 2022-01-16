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

    public static class ProductImageMapper
    {

        //public static NashRolesViewModel ToViewModel(this NashRole model)
        //{
        //    return model.Map<NashRole, NashRolesViewModel>(delegate (IMapperConfigurationExpression cfg) {
        //        cfg.CreateMap<NashRole, NashRolesViewModel>()
        //        .ForMember(x => x.NashRolesId, y => y.MapFrom(x => x.Id));
        //        }).MapAuditableFields<NashRolesViewModel>(model);
        //}
        public static ProductImage ToEntity(this ProductImageBindingModel model, int userId, ProductImage original = null)
        {
            bool flag = original != null;
            ProductImage company = flag ? model.Map<ProductImageBindingModel, ProductImage>(original) : model.Map<ProductImageBindingModel, ProductImage>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<ProductImage>(userId);
            }
            return company.MapLastModifiedFields<ProductImage>(userId);
        }
        public static NashPagedList<ProductImageViewModel> ToViewModel(this IPagedList<ProductImage> models)
        {
            List<ProductImageViewModel> viewModels = new List<ProductImageViewModel>();
            models.ToList<ProductImage>().ForEach(delegate (ProductImage a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ProductImageViewModel>(models.GetMetaData());


        }
        public static ProductImageViewModel ToViewModel(this ProductImage model)
        {
            return model.Map<ProductImage, ProductImageViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<ProductImage, ProductImageViewModel>()
                .ForMember(x => x.ProductImageId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<ProductImageViewModel>(model);

        }
    }
}

