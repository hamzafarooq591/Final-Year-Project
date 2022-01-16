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

    public static class AppointmentSlotMapper
    {
        public static AppointmentSlot ToEntity(this AppointmentSlotBindingModel model, int userId, AppointmentSlot original = null)
        {
            bool flag = original != null;
            AppointmentSlot company = flag ? model.Map<AppointmentSlotBindingModel, AppointmentSlot>(original) : model.Map<AppointmentSlotBindingModel, AppointmentSlot>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<AppointmentSlot>(userId);
            }
            return company.MapLastModifiedFields<AppointmentSlot>(userId);
        }
        public static NashPagedList<AppointmentSlotViewModel> ToViewModel(this IPagedList<AppointmentSlot> models)
        {
            List<AppointmentSlotViewModel> viewModels = new List<AppointmentSlotViewModel>();
            models.ToList<AppointmentSlot>().ForEach(delegate (AppointmentSlot a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<AppointmentSlotViewModel>(models.GetMetaData());
        }

        public static List<AppointmentSlotViewModel> ToViewModel(this List<AppointmentSlot> models)
        {
            List<AppointmentSlotViewModel> viewModels = new List<AppointmentSlotViewModel>();
            models.ToList<AppointmentSlot>().ForEach(delegate (AppointmentSlot a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

        public static AppointmentSlotViewModel ToViewModel(this AppointmentSlot model)
        {
            return model.Map<AppointmentSlot, AppointmentSlotViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<AppointmentSlot, AppointmentSlotViewModel>()
                .ForMember(x => x.SlotTime, y => y.MapFrom(x => x.SlotTime))
                .ForMember(x => x.AppointmentSlotId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<AppointmentSlotViewModel>(model);

        }
    }
}