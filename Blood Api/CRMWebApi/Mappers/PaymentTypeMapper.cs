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

    public static class PaymentTypeMapper
    {
        public static PaymentType ToEntity(this PaymentTypeBindingModel model, int userId, PaymentType original = null)
        {
            bool flag = original != null;
            PaymentType location = flag ? model.Map<PaymentTypeBindingModel, PaymentType>(original) : model.Map<PaymentTypeBindingModel, PaymentType>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<PaymentType>(userId);
            }
            return location.MapLastModifiedFields<PaymentType>(userId);
        }

        public static PaymentTypeViewModel ToViewModel(this PaymentType model)
        {

            return model.Map<PaymentType, PaymentTypeViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<PaymentType, PaymentTypeViewModel>()
                .ForMember(x => x.PaymentTypeId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<PaymentTypeViewModel>(model);
        }
        public static NashPagedList<PaymentTypeViewModel> ToViewModel(this IPagedList<PaymentType> models)
        {
            List<PaymentTypeViewModel> viewModels = new List<PaymentTypeViewModel>();
            models.ToList<PaymentType>().ForEach(delegate (PaymentType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PaymentTypeViewModel>(models.GetMetaData());
        }

        public static IList<PaymentTypeViewModel> ToViewModel(this IList<PaymentType> models)
        {
            List<PaymentTypeViewModel> viewModels = new List<PaymentTypeViewModel>();
            models.ToList<PaymentType>().ForEach(delegate (PaymentType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

