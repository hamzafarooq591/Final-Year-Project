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

    public static class StaticPageMapper
    {
        public static StaticPage ToEntity(this StaticPageBindingModel model, int userId, StaticPage original = null)
        {
            bool flag = original != null;
            StaticPage location = flag ? model.Map<StaticPageBindingModel, StaticPage>(original) : model.Map<StaticPageBindingModel, StaticPage>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<StaticPage>(userId);
            }
            return location.MapLastModifiedFields<StaticPage>(userId);
        }

        public static StaticPageViewModel ToViewModel(this StaticPage model)
        {

            return model.Map<StaticPage, StaticPageViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<StaticPage, StaticPageViewModel>()
                .ForMember(x => x.StaticPageId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<StaticPageViewModel>(model);
        }
        public static NashPagedList<StaticPageViewModel> ToViewModel(this IPagedList<StaticPage> models)
        {
            List<StaticPageViewModel> viewModels = new List<StaticPageViewModel>();
            models.ToList<StaticPage>().ForEach(delegate (StaticPage a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<StaticPageViewModel>(models.GetMetaData());
        }

        public static IList<StaticPageViewModel> ToViewModel(this IList<StaticPage> models)
        {
            List<StaticPageViewModel> viewModels = new List<StaticPageViewModel>();
            models.ToList<StaticPage>().ForEach(delegate (StaticPage a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

