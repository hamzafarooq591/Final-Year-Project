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

    public static class AccountsHeadMapper
    {
        public static AccountsHead ToEntity(this AccountsHeadBindingModel model, int userId, AccountsHead original = null)
        {
            bool flag = original != null;
            AccountsHead company = flag ? model.Map<AccountsHeadBindingModel, AccountsHead>(original) : model.Map<AccountsHeadBindingModel, AccountsHead>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<AccountsHead>(userId);
            }
            return company.MapLastModifiedFields<AccountsHead>(userId);
        }
        public static NashPagedList<AccountsHeadViewModel> ToViewModel(this IPagedList<AccountsHead> models)
        {
            List<AccountsHeadViewModel> viewModels = new List<AccountsHeadViewModel>();
            models.ToList<AccountsHead>().ForEach(delegate (AccountsHead a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<AccountsHeadViewModel>(models.GetMetaData());
        }
        public static AccountsHeadViewModel ToViewModel(this AccountsHead model)
        {
            return model.Map<AccountsHead, AccountsHeadViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<AccountsHead, AccountsHeadViewModel>()
                .ForMember(x => x.AssetId, y => y.MapFrom(x => x.Asset.Id))
                .ForMember(x => x.LiabilityId, y => y.MapFrom(x => x.Liability.Id))
                .ForMember(x => x.IncomeOrRevenueId, y => y.MapFrom(x => x.IncomeOrRevenue.Id))
                .ForMember(x => x.ExpensesId, y => y.MapFrom(x => x.Expenses.Id))
                .ForMember(x => x.EquityOrCapitalId, y => y.MapFrom(x => x.EquityOrCapital.Id))
                .ForMember(x => x.AccountsHeadId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<AccountsHeadViewModel>(model);

        }
    }
}

