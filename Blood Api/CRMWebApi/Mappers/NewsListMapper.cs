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

    public static class NewsListMapper
    {
        public static NewsList ToEntity(this NewsListBindingModel model, int userId, NewsList original = null)
        {
            bool flag = original != null;
            NewsList location = flag ? model.Map<NewsListBindingModel, NewsList>(original) : model.Map<NewsListBindingModel, NewsList>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<NewsList>(userId);
            }
            return location.MapLastModifiedFields<NewsList>(userId);
        }

        public static NewsListViewModel ToViewModel(this NewsList model)
        {

            return model.Map<NewsList, NewsListViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<NewsList, NewsListViewModel>()
                .ForMember(x => x.NewsListId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<NewsListViewModel>(model);
        }
        public static NashPagedList<NewsListViewModel> ToViewModel(this IPagedList<NewsList> models)
        {
            List<NewsListViewModel> viewModels = new List<NewsListViewModel>();
            models.ToList<NewsList>().ForEach(delegate (NewsList a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NewsListViewModel>(models.GetMetaData());
        }

        public static IList<NewsListViewModel> ToViewModel(this IList<NewsList> models)
        {
            List<NewsListViewModel> viewModels = new List<NewsListViewModel>();
            models.ToList<NewsList>().ForEach(delegate (NewsList a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

