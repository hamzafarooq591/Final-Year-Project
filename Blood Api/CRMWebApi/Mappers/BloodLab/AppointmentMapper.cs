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

    public static class AppointmentMapper
    {
        public static Appointment ToEntity(this AppointmentBindingModel model, int userId, Appointment original = null)
        {
            bool flag = original != null;
            Appointment company = flag ? model.Map<AppointmentBindingModel, Appointment>(original) : model.Map<AppointmentBindingModel, Appointment>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Appointment>(userId);
            }
            return company.MapLastModifiedFields<Appointment>(userId);
        }
        public static NashPagedList<AppointmentViewModel> ToViewModel(this IPagedList<Appointment> models)
        {
            List<AppointmentViewModel> viewModels = new List<AppointmentViewModel>();
            models.ToList<Appointment>().ForEach(delegate (Appointment a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<AppointmentViewModel>(models.GetMetaData());
        }

        public static List<AppointmentViewModel> ToViewModel(this List<Appointment> models)
        {
            List<AppointmentViewModel> viewModels = new List<AppointmentViewModel>();
            models.ToList<Appointment>().ForEach(delegate (Appointment a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

        public static AppointmentViewModel ToViewModel(this Appointment model)
        {
            return model.Map<Appointment, AppointmentViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Appointment, AppointmentViewModel>()
                .ForMember(x => x.PatientName, y => y.MapFrom(x => x.Patient.FullName))
                .ForMember(x => x.AppointmentId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<AppointmentViewModel>(model);

        }
    }
}