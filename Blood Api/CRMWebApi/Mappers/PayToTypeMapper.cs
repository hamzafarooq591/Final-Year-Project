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

    public static class PayToTypeMapper
    {
        public static PayToType ToEntity(this PayToTypeBindingModel model, int userId, PayToType original = null)
        {
            bool flag = original != null;
            PayToType location = flag ? model.Map<PayToTypeBindingModel, PayToType>(original) : model.Map<PayToTypeBindingModel, PayToType>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<PayToType>(userId);
            }
            return location.MapLastModifiedFields<PayToType>(userId);
        }

        public static PayToTypeViewModel ToViewModel(this PayToType model)
        {

            return model.Map<PayToType, PayToTypeViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<PayToType, PayToTypeViewModel>()
                .ForMember(x => x.PayToTypeId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<PayToTypeViewModel>(model);
        }
        public static NashPagedList<PayToTypeViewModel> ToViewModel(this IPagedList<PayToType> models)
        {
            List<PayToTypeViewModel> viewModels = new List<PayToTypeViewModel>();
            models.ToList<PayToType>().ForEach(delegate (PayToType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PayToTypeViewModel>(models.GetMetaData());
        }

        public static IList<PayToTypeViewModel> ToViewModel(this IList<PayToType> models)
        {
            List<PayToTypeViewModel> viewModels = new List<PayToTypeViewModel>();
            models.ToList<PayToType>().ForEach(delegate (PayToType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

