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

    public static class ManufacturerMapper
    {

        //public static NashRolesViewModel ToViewModel(this NashRole model)
        //{
        //    return model.Map<NashRole, NashRolesViewModel>(delegate (IMapperConfigurationExpression cfg) {
        //        cfg.CreateMap<NashRole, NashRolesViewModel>()
        //        .ForMember(x => x.NashRolesId, y => y.MapFrom(x => x.Id));
        //        }).MapAuditableFields<NashRolesViewModel>(model);
        //}
        public static Manufacturer ToEntity(this ManufacturerBindingModel model, int userId, Manufacturer original = null)
        {
            bool flag = original != null;
            Manufacturer company = flag ? model.Map<ManufacturerBindingModel, Manufacturer>(original) : model.Map<ManufacturerBindingModel, Manufacturer>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Manufacturer>(userId);
            }
            return company.MapLastModifiedFields<Manufacturer>(userId);
        }
        public static NashPagedList<ManufacturerViewModel> ToViewModel(this IPagedList<Manufacturer> models)
        {
            List<ManufacturerViewModel> viewModels = new List<ManufacturerViewModel>();
            models.ToList<Manufacturer>().ForEach(delegate (Manufacturer a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ManufacturerViewModel>(models.GetMetaData());
        }
        public static ManufacturerViewModel ToViewModel(this Manufacturer model)
        {
            return model.Map<Manufacturer, ManufacturerViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Manufacturer, ManufacturerViewModel>()
                .ForMember(x => x.ManufacturerId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ImageId, y => y.MapFrom(x => x.ManufacturerImage.Id))
                .ForMember(x => x.ManufacturerImageUpload, y => y.MapFrom(x => x.ManufacturerImage.fileUrl))
                .ForMember(x => x.ManufacturerName, y => y.MapFrom(x => x.ManufacturerName));
            }).MapAuditableFields<ManufacturerViewModel>(model);

        }

    }
}

