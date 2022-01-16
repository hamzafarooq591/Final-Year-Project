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

    public static class CompanySettingMapper
    {
        public static CompanySetting ToEntity(this CompanySettingBindingModel model, int userId, CompanySetting original = null)
        {
            bool flag = original != null;
            CompanySetting company = flag ? model.Map<CompanySettingBindingModel, CompanySetting>(original) : model.Map<CompanySettingBindingModel, CompanySetting>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<CompanySetting>(userId);
            }
            return company.MapLastModifiedFields<CompanySetting>(userId);
        }
        public static NashPagedList<CompanySettingViewModel> ToViewModel(this IPagedList<CompanySetting> models)
        {
            List<CompanySettingViewModel> viewModels = new List<CompanySettingViewModel>();
            models.ToList<CompanySetting>().ForEach(delegate (CompanySetting a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<CompanySettingViewModel>(models.GetMetaData());
        }
        public static CompanySettingViewModel ToViewModel(this CompanySetting model)
        {
            return model.Map<CompanySetting, CompanySettingViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<CompanySetting, CompanySettingViewModel>()
                .ForMember(x => x.CompanySettingId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<CompanySettingViewModel>(model);

        }
    }
}

