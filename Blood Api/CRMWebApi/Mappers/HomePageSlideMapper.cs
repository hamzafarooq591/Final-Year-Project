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

    public static class HomePageSlideMapper
    {

        //public static NashRolesViewModel ToViewModel(this NashRole model)
        //{
        //    return model.Map<NashRole, NashRolesViewModel>(delegate (IMapperConfigurationExpression cfg) {
        //        cfg.CreateMap<NashRole, NashRolesViewModel>()
        //        .ForMember(x => x.NashRolesId, y => y.MapFrom(x => x.Id));
        //        }).MapAuditableFields<NashRolesViewModel>(model);
        //}
        public static HomePageSlide ToEntity(this HomePageSlideBindingModel model, int userId, HomePageSlide original = null)
        {
            bool flag = original != null;
            HomePageSlide company = flag ? model.Map<HomePageSlideBindingModel, HomePageSlide>(original) : model.Map<HomePageSlideBindingModel, HomePageSlide>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<HomePageSlide>(userId);
            }
            return company.MapLastModifiedFields<HomePageSlide>(userId);
        }
        public static NashPagedList<HomePageSlideViewModel> ToViewModel(this IPagedList<HomePageSlide> models)
        {
            List<HomePageSlideViewModel> viewModels = new List<HomePageSlideViewModel>();
            models.ToList<HomePageSlide>().ForEach(delegate (HomePageSlide a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<HomePageSlideViewModel>(models.GetMetaData());
        }
        public static HomePageSlideViewModel ToViewModel(this HomePageSlide model)
        {
            return model.Map<HomePageSlide, HomePageSlideViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<HomePageSlide, HomePageSlideViewModel>()
                .ForMember(x => x.HomePageSlideId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.SliderImageId, y => y.MapFrom(x => x.SlideImage.Id));
            }).MapAuditableFields<HomePageSlideViewModel>(model);

        }

    }
}

