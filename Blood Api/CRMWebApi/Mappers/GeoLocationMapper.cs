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

    public static class GeoLocationMapper
    {
        public static GeoLocation ToEntity(this GeoLocationBindingModel model, int userId, GeoLocation original = null)
        {
            bool flag = original != null;
            GeoLocation location = flag ? model.Map<GeoLocationBindingModel, GeoLocation>(original) : model.Map<GeoLocationBindingModel, GeoLocation>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<GeoLocation>(userId);
            }
            return location.MapLastModifiedFields<GeoLocation>(userId);
        }

        public static GeoLocationViewModel ToViewModel(this GeoLocation model)
        {

            return model.Map<GeoLocation, GeoLocationViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<GeoLocation, GeoLocationViewModel>()
                .ForMember(x => x.GeoLocationId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<GeoLocationViewModel>(model);
        }
        public static NashPagedList<GeoLocationViewModel> ToViewModel(this IPagedList<GeoLocation> models)
        {
            List<GeoLocationViewModel> viewModels = new List<GeoLocationViewModel>();
            models.ToList<GeoLocation>().ForEach(delegate (GeoLocation a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<GeoLocationViewModel>(models.GetMetaData());
        }

        public static IList<GeoLocationViewModel> ToViewModel(this IList<GeoLocation> models)
        {
            List<GeoLocationViewModel> viewModels = new List<GeoLocationViewModel>();
            models.ToList<GeoLocation>().ForEach(delegate (GeoLocation a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

