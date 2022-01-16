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

    public static class NashRolesMapper
    {
        
        //public static NashRolesViewModel ToViewModel(this NashRole model)
        //{
        //    return model.Map<NashRole, NashRolesViewModel>(delegate (IMapperConfigurationExpression cfg) {
        //        cfg.CreateMap<NashRole, NashRolesViewModel>()
        //        .ForMember(x => x.NashRolesId, y => y.MapFrom(x => x.Id));
        //        }).MapAuditableFields<NashRolesViewModel>(model);
        //}

        public static NashPagedList<NashRolesViewModel> ToViewModel(this IPagedList<NashRole> models)
        {
            List<NashRolesViewModel> viewModels = new List<NashRolesViewModel>();
            models.ToList<NashRole>().ForEach(delegate (NashRole a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NashRolesViewModel>(models.GetMetaData());
        }
        public static NashRolesViewModel ToViewModel(this NashRole model)
        {
            return model.Map<NashRole, NashRolesViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<NashRole, NashRolesViewModel>()
                .ForMember(x => x.NashRolesId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name));
            }).MapAuditableFields<NashRolesViewModel>(model);

            //return model.Map<City, CityViewModel>(delegate (IMapperConfigurationExpression cfg) {
            //    cfg.CreateMap<City, CityViewModel>()
            //    .ForMember(x => x.CityId, y => y.MapFrom(x => x.Id))
            //    .ForMember(x => x.GeoLocationName, y => y.MapFrom(x => x.GeoLocation.CountryName));
            //}).MapAuditableFields<CityViewModel>(model);

        }

    }
}

