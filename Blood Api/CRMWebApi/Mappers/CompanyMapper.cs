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

    public static class CompanyMapper
    {

        //public static NashRolesViewModel ToViewModel(this NashRole model)
        //{
        //    return model.Map<NashRole, NashRolesViewModel>(delegate (IMapperConfigurationExpression cfg) {
        //        cfg.CreateMap<NashRole, NashRolesViewModel>()
        //        .ForMember(x => x.NashRolesId, y => y.MapFrom(x => x.Id));
        //        }).MapAuditableFields<NashRolesViewModel>(model);
        //}
        public static NashCompany ToEntity(this CompanyBindingModel model, int userId, NashCompany original = null)
        {
            bool flag = original != null;
            NashCompany company = flag ? model.Map<CompanyBindingModel, NashCompany>(original) : model.Map<CompanyBindingModel, NashCompany>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<NashCompany>(userId);
            }
            return company.MapLastModifiedFields<NashCompany>(userId);
        }
        public static NashPagedList<CompanyViewModel> ToViewModel(this IPagedList<NashCompany> models)
        {
            List<CompanyViewModel> viewModels = new List<CompanyViewModel>();
            models.ToList<NashCompany>().ForEach(delegate (NashCompany a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<CompanyViewModel>(models.GetMetaData());
        }
        public static CompanyViewModel ToViewModel(this NashCompany model)
        {
            return model.Map<NashCompany, CompanyViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<NashCompany, CompanyViewModel>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name));
            }).MapAuditableFields<CompanyViewModel>(model);

            //return model.Map<City, CityViewModel>(delegate (IMapperConfigurationExpression cfg) {
            //    cfg.CreateMap<City, CityViewModel>()
            //    .ForMember(x => x.CityId, y => y.MapFrom(x => x.Id))
            //    .ForMember(x => x.GeoLocationName, y => y.MapFrom(x => x.GeoLocation.CountryName));
            //}).MapAuditableFields<CityViewModel>(model);

        }

    }
}

