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

    public static class CourierCompanyMapper
    {
        public static CourierCompany ToEntity(this CourierCompanyBindingModel model, int userId, CourierCompany original = null)
        {
            bool flag = original != null;
            CourierCompany location = flag ? model.Map<CourierCompanyBindingModel, CourierCompany>(original) : model.Map<CourierCompanyBindingModel, CourierCompany>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<CourierCompany>(userId);
            }
            return location.MapLastModifiedFields<CourierCompany>(userId);
        }

        public static CourierCompanyViewModel ToViewModel(this CourierCompany model)
        {

            return model.Map<CourierCompany, CourierCompanyViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<CourierCompany, CourierCompanyViewModel>()
                .ForMember(x => x.CourierCompanyId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<CourierCompanyViewModel>(model);
        }
        public static NashPagedList<CourierCompanyViewModel> ToViewModel(this IPagedList<CourierCompany> models)
        {
            List<CourierCompanyViewModel> viewModels = new List<CourierCompanyViewModel>();
            models.ToList<CourierCompany>().ForEach(delegate (CourierCompany a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<CourierCompanyViewModel>(models.GetMetaData());
        }

        public static IList<CourierCompanyViewModel> ToViewModel(this IList<CourierCompany> models)
        {
            List<CourierCompanyViewModel> viewModels = new List<CourierCompanyViewModel>();
            models.ToList<CourierCompany>().ForEach(delegate (CourierCompany a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

