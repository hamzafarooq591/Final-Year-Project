namespace NashWebApi.Mappers.BloodLab
{
    using AutoMapper;
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class AppointmentTestMapper
    {
        public static AppointmentTest ToEntity(this AppointmentTestBindingModel model, int userId, AppointmentTest original = null)
        {
            bool flag = original != null;
            AppointmentTest company = flag ? model.Map<AppointmentTestBindingModel, AppointmentTest>(original) : model.Map<AppointmentTestBindingModel, AppointmentTest>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<AppointmentTest>(userId);
            }
            return company.MapLastModifiedFields<AppointmentTest>(userId);
        }

        public static List<AppointmentTestViewModel> ToViewModel(this List<AppointmentTest> models)
        {
            List<AppointmentTestViewModel> viewModels = new List<AppointmentTestViewModel>();
            models.ToList<AppointmentTest>().ForEach(delegate (AppointmentTest a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }
        public static NashPagedList<AppointmentTestViewModel> ToViewModel(this IPagedList<AppointmentTest> models)
        {
            List<AppointmentTestViewModel> viewModels = new List<AppointmentTestViewModel>();
            models.ToList<AppointmentTest>().ForEach(delegate (AppointmentTest a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<AppointmentTestViewModel>(models.GetMetaData());
        }
        public static AppointmentTestViewModel ToViewModel(this AppointmentTest model)
        {
            return model.Map<AppointmentTest, AppointmentTestViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<AppointmentTest, AppointmentTestViewModel>()
                .ForMember(x => x.AppointmentTestId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<AppointmentTestViewModel>(model);

        }


       
    }
}

