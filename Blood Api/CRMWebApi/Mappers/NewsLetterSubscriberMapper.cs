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

    public static class NewsLetterSubscriberMapper
    {
        public static NewsLetterSubscriber ToEntity(this NewsLetterSubscriberBindingModel model, int userId, NewsLetterSubscriber original = null)
        {
            bool flag = original != null;
            NewsLetterSubscriber company = flag ? model.Map<NewsLetterSubscriberBindingModel, NewsLetterSubscriber>(original) : model.Map<NewsLetterSubscriberBindingModel, NewsLetterSubscriber>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<NewsLetterSubscriber>(userId);
            }
            return company.MapLastModifiedFields<NewsLetterSubscriber>(userId);
        }
        public static NashPagedList<NewsLetterSubscriberViewModel> ToViewModel(this IPagedList<NewsLetterSubscriber> models)
        {
            List<NewsLetterSubscriberViewModel> viewModels = new List<NewsLetterSubscriberViewModel>();
            models.ToList<NewsLetterSubscriber>().ForEach(delegate (NewsLetterSubscriber a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NewsLetterSubscriberViewModel>(models.GetMetaData());
        }
        public static NewsLetterSubscriberViewModel ToViewModel(this NewsLetterSubscriber model)
        {
            return model.Map<NewsLetterSubscriber, NewsLetterSubscriberViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<NewsLetterSubscriber, NewsLetterSubscriberViewModel>()
                .ForMember(x => x.NashUserId, y => y.MapFrom(x => x.NashUser.Id))
                .ForMember(x => x.NashUserEmailAddress, y => y.MapFrom(x => x.NashUser.Email))
                .ForMember(x => x.NewsLetterSubscriberId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<NewsLetterSubscriberViewModel>(model);

        }
    }
}

