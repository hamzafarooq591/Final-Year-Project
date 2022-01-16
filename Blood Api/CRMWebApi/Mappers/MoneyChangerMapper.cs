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

    public static class MoneyChangerMapper
    {
        public static MoneyChanger ToEntity(this MoneyChangerBindingModel model, int userId, MoneyChanger original = null)
        {
            bool flag = original != null;
            MoneyChanger company = flag ? model.Map<MoneyChangerBindingModel, MoneyChanger>(original) : model.Map<MoneyChangerBindingModel, MoneyChanger>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<MoneyChanger>(userId);
            }
            return company.MapLastModifiedFields<MoneyChanger>(userId);
        }
        public static NashPagedList<MoneyChangerViewModel> ToViewModel(this IPagedList<MoneyChanger> models)
        {
            List<MoneyChangerViewModel> viewModels = new List<MoneyChangerViewModel>();
            models.ToList<MoneyChanger>().ForEach(delegate (MoneyChanger a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<MoneyChangerViewModel>(models.GetMetaData());
        }
        public static MoneyChangerViewModel ToViewModel(this MoneyChanger model)
        {
            return model.Map<MoneyChanger, MoneyChangerViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<MoneyChanger, MoneyChangerViewModel>()
                .ForMember(x => x.MCAccountId, y => y.MapFrom(x => x.Account.Id))
                .ForMember(x => x.MoneyChangerId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<MoneyChangerViewModel>(model);

        }
    }
}

