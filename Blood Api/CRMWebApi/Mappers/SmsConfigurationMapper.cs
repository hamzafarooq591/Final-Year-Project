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

    public static class SmsConfigurationMapper
    {
        public static SmsConfiguration ToEntity(this SmsConfigurationBindingModel model, int userId, SmsConfiguration original = null)
        {
            bool flag = original != null;
            SmsConfiguration company = flag ? model.Map<SmsConfigurationBindingModel, SmsConfiguration>(original) : model.Map<SmsConfigurationBindingModel, SmsConfiguration>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<SmsConfiguration>(userId);
            }
            return company.MapLastModifiedFields<SmsConfiguration>(userId);
        }
        public static NashPagedList<SmsConfigurationViewModel> ToViewModel(this IPagedList<SmsConfiguration> models)
        {
            List<SmsConfigurationViewModel> viewModels = new List<SmsConfigurationViewModel>();
            models.ToList<SmsConfiguration>().ForEach(delegate (SmsConfiguration a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<SmsConfigurationViewModel>(models.GetMetaData());
        }
        public static SmsConfigurationViewModel ToViewModel(this SmsConfiguration model)
        {
            return model.Map<SmsConfiguration, SmsConfigurationViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<SmsConfiguration, SmsConfigurationViewModel>()
                .ForMember(x => x.SmsTypeId, y => y.MapFrom(x => x.SmsType.Id))
                .ForMember(x => x.SmsConfigurationId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<SmsConfigurationViewModel>(model);

        }
    }
}

