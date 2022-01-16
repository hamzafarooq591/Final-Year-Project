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

    public static class PageContentMapper
    {
        public static PageContent ToEntity(this PageContentBindingModel model, int userId, PageContent original = null)
        {
            bool flag = original != null;
            PageContent company = flag ? model.Map<PageContentBindingModel, PageContent>(original) : model.Map<PageContentBindingModel, PageContent>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<PageContent>(userId);
            }
            return company.MapLastModifiedFields<PageContent>(userId);
        }
        public static NashPagedList<PageContentViewModel> ToViewModel(this IPagedList<PageContent> models)
        {
            List<PageContentViewModel> viewModels = new List<PageContentViewModel>();
            models.ToList<PageContent>().ForEach(delegate (PageContent a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PageContentViewModel>(models.GetMetaData());
        }
        public static PageContentViewModel ToViewModel(this PageContent model)
        {
            return model.Map<PageContent, PageContentViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<PageContent, PageContentViewModel>()
                .ForMember(x => x.StaticPageId, y => y.MapFrom(x => x.StaticPage.Id))
                .ForMember(x => x.PageContentId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<PageContentViewModel>(model);

        }
    }
}

