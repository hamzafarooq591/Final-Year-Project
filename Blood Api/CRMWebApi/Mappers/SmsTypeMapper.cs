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

    public static class SmsTypeMapper
    {
        public static SmsType ToEntity(this SmsTypeBindingModel model, int userId, SmsType original = null)
        {
            bool flag = original != null;
            SmsType location = flag ? model.Map<SmsTypeBindingModel, SmsType>(original) : model.Map<SmsTypeBindingModel, SmsType>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<SmsType>(userId);
            }
            return location.MapLastModifiedFields<SmsType>(userId);
        }

        public static SmsTypeViewModel ToViewModel(this SmsType model)
        {

            return model.Map<SmsType, SmsTypeViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<SmsType, SmsTypeViewModel>()
                .ForMember(x => x.SmsTypeId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<SmsTypeViewModel>(model);
        }
        public static NashPagedList<SmsTypeViewModel> ToViewModel(this IPagedList<SmsType> models)
        {
            List<SmsTypeViewModel> viewModels = new List<SmsTypeViewModel>();
            models.ToList<SmsType>().ForEach(delegate (SmsType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<SmsTypeViewModel>(models.GetMetaData());
        }

        public static IList<SmsTypeViewModel> ToViewModel(this IList<SmsType> models)
        {
            List<SmsTypeViewModel> viewModels = new List<SmsTypeViewModel>();
            models.ToList<SmsType>().ForEach(delegate (SmsType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

