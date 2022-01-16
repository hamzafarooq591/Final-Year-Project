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

    public static class AppointmentOfferMapper
    {
        public static AppointmentOffer ToEntity(this AppointmentOfferBindingModel model, int userId, AppointmentOffer original = null)
        {
            bool flag = original != null;
            AppointmentOffer company = flag ? model.Map<AppointmentOfferBindingModel, AppointmentOffer>(original) : model.Map<AppointmentOfferBindingModel, AppointmentOffer>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<AppointmentOffer>(userId);
            }
            return company.MapLastModifiedFields<AppointmentOffer>(userId);
        }
        public static NashPagedList<AppointmentOfferViewModel> ToViewModel(this IPagedList<AppointmentOffer> models)
        {
            List<AppointmentOfferViewModel> viewModels = new List<AppointmentOfferViewModel>();
            models.ToList<AppointmentOffer>().ForEach(delegate (AppointmentOffer a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<AppointmentOfferViewModel>(models.GetMetaData());
        }
        public static AppointmentOfferViewModel ToViewModel(this AppointmentOffer model)
        {
            return model.Map<AppointmentOffer, AppointmentOfferViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<AppointmentOffer, AppointmentOfferViewModel>()
                .ForMember(x => x.AppointmentOfferId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<AppointmentOfferViewModel>(model);

        }


       
    }
}

