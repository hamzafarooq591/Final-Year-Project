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

    public static class NewsLetterMapper
    {
        public static NewsLetter ToEntity(this NewsLetterBindingModel model, int userId, NewsLetter original = null)
        {
            bool flag = original != null;
            NewsLetter location = flag ? model.Map<NewsLetterBindingModel, NewsLetter>(original) : model.Map<NewsLetterBindingModel, NewsLetter>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<NewsLetter>(userId);
            }
            return location.MapLastModifiedFields<NewsLetter>(userId);
        }

        public static NewsLetterViewModel ToViewModel(this NewsLetter model)
        {

            return model.Map<NewsLetter, NewsLetterViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<NewsLetter, NewsLetterViewModel>()
                .ForMember(x => x.NewsLetterId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<NewsLetterViewModel>(model);
        }
        public static NashPagedList<NewsLetterViewModel> ToViewModel(this IPagedList<NewsLetter> models)
        {
            List<NewsLetterViewModel> viewModels = new List<NewsLetterViewModel>();
            models.ToList<NewsLetter>().ForEach(delegate (NewsLetter a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NewsLetterViewModel>(models.GetMetaData());
        }

        public static IList<NewsLetterViewModel> ToViewModel(this IList<NewsLetter> models)
        {
            List<NewsLetterViewModel> viewModels = new List<NewsLetterViewModel>();
            models.ToList<NewsLetter>().ForEach(delegate (NewsLetter a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

