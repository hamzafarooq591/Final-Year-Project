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

    public static class CategoryMapper
    {

        //public static NashRolesViewModel ToViewModel(this NashRole model)
        //{
        //    return model.Map<NashRole, NashRolesViewModel>(delegate (IMapperConfigurationExpression cfg) {
        //        cfg.CreateMap<NashRole, NashRolesViewModel>()
        //        .ForMember(x => x.NashRolesId, y => y.MapFrom(x => x.Id));
        //        }).MapAuditableFields<NashRolesViewModel>(model);
        //}
        public static Category ToEntity(this CategoryBindingModel model, int userId, Category original = null)
        {
            bool flag = original != null;
            Category company = flag ? model.Map<CategoryBindingModel, Category>(original) : model.Map<CategoryBindingModel, Category>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Category>(userId);
            }
            return company.MapLastModifiedFields<Category>(userId);
        }
        public static NashPagedList<CategoryViewModel> ToViewModel(this IPagedList<Category> models)
        {
            List<CategoryViewModel> viewModels = new List<CategoryViewModel>();
            models.ToList<Category>().ForEach(delegate (Category a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<CategoryViewModel>(models.GetMetaData());


        }
        public static CategoryViewModel ToViewModel(this Category model)
        {
            return model.Map<Category, CategoryViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Category, CategoryViewModel>()
                .ForMember(x => x.ManufacturerName, y => y.MapFrom(x => x.Manufacturer.ManufacturerName))
                .ForMember(x => x.ManufacturerId, y => y.MapFrom(x => x.Manufacturer.Id))
                .ForMember(x => x.CategoryId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ImageId, y => y.MapFrom(x => x.CategoryImage.Id))
                .ForMember(x => x.CategoryImageUpload, y => y.MapFrom(x => x.CategoryImage.fileUrl))
                .ForMember(x => x.CategoryName, y => y.MapFrom(x => x.CategoryName));
            }).MapAuditableFields<CategoryViewModel>(model);

        }
    }
}

