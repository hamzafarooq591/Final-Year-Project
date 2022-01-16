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

    public static class NashPageMapper
    {
        public static NashPage ToEntity(this NashPageBindingModel model, int userId, NashPage original = null)
        {
            bool flag = original != null;
            NashPage page = flag ? model.Map<NashPageBindingModel, NashPage>(original) : model.Map<NashPageBindingModel, NashPage>();
            if (!flag)
            {
                return page.MapCreatedAndLastModifiedFields<NashPage>(userId);
            }
            return page.MapLastModifiedFields<NashPage>(userId);
        }

        public static NashPageViewModel ToViewModel(this NashPage model)
        {
          return model.Map<NashPage, NashPageViewModel>(delegate (IMapperConfigurationExpression cfg)
            {

                cfg.CreateMap<NashPage, NashPageViewModel>()
                .ForMember(x => x.ParentPageName, y => y.MapFrom(x => x.ParentPage.Title))
                .ForMember(x => x.NashPageId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<NashPageViewModel>(model);
        }
        public static NashPagedList<NashPageViewModel> ToViewModel(this IPagedList<NashPage> models)
        {
            List<NashPageViewModel> viewModels = new List<NashPageViewModel>();
            models.ToList<NashPage>().ForEach(delegate (NashPage a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NashPageViewModel>(models.GetMetaData());
        }

        public static IList<NashPageViewModel> ToViewModel(this IList<NashPage> models)
        {
            List<NashPageViewModel> viewModels = new List<NashPageViewModel>();
            models.ToList<NashPage>().ForEach(delegate (NashPage a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }
    }
}

