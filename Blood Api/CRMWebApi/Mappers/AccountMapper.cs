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

    public static class AccountMapper
    {
        public static Account ToEntity(this AccountBindingModel model, int userId, Account original = null)
        {
            bool flag = original != null;
            Account company = flag ? model.Map<AccountBindingModel, Account>(original) : model.Map<AccountBindingModel, Account>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Account>(userId);
            }
            return company.MapLastModifiedFields<Account>(userId);
        }
        public static NashPagedList<AccountViewModel> ToViewModel(this IPagedList<Account> models)
        {
            List<AccountViewModel> viewModels = new List<AccountViewModel>();
            models.ToList<Account>().ForEach(delegate (Account a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<AccountViewModel>(models.GetMetaData());
        }
        public static AccountViewModel ToViewModel(this Account model)
        {
            return model.Map<Account, AccountViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Account, AccountViewModel>()
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Branch.Id))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Branch.BranchName))
                .ForMember(x => x.AccountId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ParentAccountName, y => y.MapFrom(x => x.ParentAccount.AccountName));
            }).MapAuditableFields<AccountViewModel>(model);

        }

        public static TrailBalanceViewModel ToTrailBalanceViewModel(this Account model)
        {
            return model.Map<Account, TrailBalanceViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Account, TrailBalanceViewModel>()
                .ForMember(x => x.AccountId, y => y.MapFrom(x => x.Id));
            });

        }

        public static NashPagedList<TrailBalanceViewModel> ToTrailBalanceViewModel(this IPagedList<Account> models)
        {
            List<TrailBalanceViewModel> viewModels = new List<TrailBalanceViewModel>();
            models.ToList<Account>().ForEach(delegate (Account a) {
                
                viewModels.Add(a.ToTrailBalanceViewModel());
            });
            return viewModels.ToNashPagedList<TrailBalanceViewModel>(models.GetMetaData());
        }

        public static ProfitLossReportViewModel ToProfitAndLossViewModel(this Account model)
        {
            return model.Map<Account, ProfitLossReportViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Account, ProfitLossReportViewModel>();
            });

        }

        public static NashPagedList<ProfitLossReportViewModel> ToProfitAndLossViewModel(this IPagedList<Account> models)
        {
            List<ProfitLossReportViewModel> viewModels = new List<ProfitLossReportViewModel>();
            models.ToList<Account>().ForEach(delegate (Account a) {

                viewModels.Add(a.ToProfitAndLossViewModel());
            });
            return viewModels.ToNashPagedList<ProfitLossReportViewModel>(models.GetMetaData());
        }
    }
}

