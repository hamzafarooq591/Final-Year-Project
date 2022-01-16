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

    public static class SiteSettingMapper
    {
        public static SiteSetting ToEntity(this SiteSettingBindingModel model, int userId, SiteSetting original = null)
        {
            bool flag = original != null;
            SiteSetting location = flag ? model.Map<SiteSettingBindingModel, SiteSetting>(original) : model.Map<SiteSettingBindingModel, SiteSetting>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<SiteSetting>(userId);
            }
            return location.MapLastModifiedFields<SiteSetting>(userId);
        }

        public static SiteSettingViewModel ToViewModel(this SiteSetting model)
        {

            return model.Map<SiteSetting, SiteSettingViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<SiteSetting, SiteSettingViewModel>()
                .ForMember(x => x.SiteSettingId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<SiteSettingViewModel>(model);
        }
        public static NashPagedList<SiteSettingViewModel> ToViewModel(this IPagedList<SiteSetting> models)
        {
            List<SiteSettingViewModel> viewModels = new List<SiteSettingViewModel>();
            models.ToList<SiteSetting>().ForEach(delegate (SiteSetting a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<SiteSettingViewModel>(models.GetMetaData());
        }

        public static IList<SiteSettingViewModel> ToViewModel(this IList<SiteSetting> models)
        {
            List<SiteSettingViewModel> viewModels = new List<SiteSettingViewModel>();
            models.ToList<SiteSetting>().ForEach(delegate (SiteSetting a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

