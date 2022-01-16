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

    public static class NewsConfigurationMapper
    {
        public static NewsConfiguration ToEntity(this NewsConfigurationBindingModel model, int userId, NewsConfiguration original = null)
        {
            bool flag = original != null;
            NewsConfiguration location = flag ? model.Map<NewsConfigurationBindingModel, NewsConfiguration>(original) : model.Map<NewsConfigurationBindingModel, NewsConfiguration>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<NewsConfiguration>(userId);
            }
            return location.MapLastModifiedFields<NewsConfiguration>(userId);
        }

        public static NewsConfigurationViewModel ToViewModel(this NewsConfiguration model)
        {

            return model.Map<NewsConfiguration, NewsConfigurationViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<NewsConfiguration, NewsConfigurationViewModel>()
                .ForMember(x => x.NewsConfigurationId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<NewsConfigurationViewModel>(model);
        }
        public static NashPagedList<NewsConfigurationViewModel> ToViewModel(this IPagedList<NewsConfiguration> models)
        {
            List<NewsConfigurationViewModel> viewModels = new List<NewsConfigurationViewModel>();
            models.ToList<NewsConfiguration>().ForEach(delegate (NewsConfiguration a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NewsConfigurationViewModel>(models.GetMetaData());
        }

        public static IList<NewsConfigurationViewModel> ToViewModel(this IList<NewsConfiguration> models)
        {
            List<NewsConfigurationViewModel> viewModels = new List<NewsConfigurationViewModel>();
            models.ToList<NewsConfiguration>().ForEach(delegate (NewsConfiguration a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

