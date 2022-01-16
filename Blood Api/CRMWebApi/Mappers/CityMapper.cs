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

    public static class CityMapper
    {
        public static City ToEntity(this CityBindingModel model, int userId, City original = null)
        {
            bool flag = original != null;
            City city = flag ? model.Map<CityBindingModel, City>(original) : model.Map<CityBindingModel, City>();
            if (!flag)
            {
                return city.MapCreatedAndLastModifiedFields<City>(userId);
            }
            return city.MapLastModifiedFields<City>(userId);
        }

        public static CityViewModel ToViewModel(this City model)
        {
            return model.Map<City, CityViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<City, CityViewModel>()
                .ForMember(x => x.CityId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.GeoLocationName, y => y.MapFrom(x => x.GeoLocation.CountryName));
                }).MapAuditableFields<CityViewModel>(model);
            }
        public static NashPagedList<CityViewModel> ToViewModel(this IPagedList<City> models)
        {
            List<CityViewModel> viewModels = new List<CityViewModel>();
            models.ToList<City>().ForEach(delegate (City a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<CityViewModel>(models.GetMetaData());
        }

        public static IList<CityViewModel> ToViewModel(this IList<City> models)
        {
            List<CityViewModel> viewModels = new List<CityViewModel>();
            models.ToList<City>().ForEach(delegate (City a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

        
    }
}

