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

    public static class NewsLetterTemplateMapper
    {
        public static NewsLetterTemplate ToEntity(this NewsLetterTemplateBindingModel model, int userId, NewsLetterTemplate original = null)
        {
            bool flag = original != null;
            NewsLetterTemplate location = flag ? model.Map<NewsLetterTemplateBindingModel, NewsLetterTemplate>(original) : model.Map<NewsLetterTemplateBindingModel, NewsLetterTemplate>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<NewsLetterTemplate>(userId);
            }
            return location.MapLastModifiedFields<NewsLetterTemplate>(userId);
        }

        public static NewsLetterTemplateViewModel ToViewModel(this NewsLetterTemplate model)
        {

            return model.Map<NewsLetterTemplate, NewsLetterTemplateViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<NewsLetterTemplate, NewsLetterTemplateViewModel>()
                .ForMember(x => x.NewsLetterTemplateId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<NewsLetterTemplateViewModel>(model);
        }
        public static NashPagedList<NewsLetterTemplateViewModel> ToViewModel(this IPagedList<NewsLetterTemplate> models)
        {
            List<NewsLetterTemplateViewModel> viewModels = new List<NewsLetterTemplateViewModel>();
            models.ToList<NewsLetterTemplate>().ForEach(delegate (NewsLetterTemplate a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NewsLetterTemplateViewModel>(models.GetMetaData());
        }

        public static IList<NewsLetterTemplateViewModel> ToViewModel(this IList<NewsLetterTemplate> models)
        {
            List<NewsLetterTemplateViewModel> viewModels = new List<NewsLetterTemplateViewModel>();
            models.ToList<NewsLetterTemplate>().ForEach(delegate (NewsLetterTemplate a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

