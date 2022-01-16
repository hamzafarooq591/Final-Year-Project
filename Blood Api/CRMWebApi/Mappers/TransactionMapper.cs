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

    public static class TransactionMapper
    {
        public static Transaction ToEntity(this TransactionBindingModel model, int userId, Transaction original = null)
        {
            bool flag = original != null;
            Transaction company = flag ? model.Map<TransactionBindingModel, Transaction>(original) : model.Map<TransactionBindingModel, Transaction>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Transaction>(userId);
            }
            return company.MapLastModifiedFields<Transaction>(userId);
        }
        public static NashPagedList<TransactionViewModel> ToViewModel(this IPagedList<Transaction> models)
        {
            List<TransactionViewModel> viewModels = new List<TransactionViewModel>();
            models.ToList<Transaction>().ForEach(delegate (Transaction a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<TransactionViewModel>(models.GetMetaData());
        }

        public static NashPagedList<LedgerViewModel> ToLedgerViewModel(this IPagedList<Transaction> models)
        {
            List<LedgerViewModel> viewModels = new List<LedgerViewModel>();
            models.ToList<Transaction>().ForEach(delegate (Transaction a) {
                viewModels.Add(a.ToLedgerViewModel());
            });
            return viewModels.ToNashPagedList<LedgerViewModel>(models.GetMetaData());
        }

        public static NashPagedList<TransactionInquiryViewModel> ToTransactionInquiryViewModel(this IPagedList<Transaction> models)
        {
            List<TransactionInquiryViewModel> viewModels = new List<TransactionInquiryViewModel>();
            models.ToList<Transaction>().ForEach(delegate (Transaction a) {
                viewModels.Add(a.ToTransactionInquiryViewModel());
            });
            return viewModels.ToNashPagedList<TransactionInquiryViewModel>(models.GetMetaData());
        }


        public static TransactionInquiryViewModel ToTransactionInquiryViewModel(this Transaction model)
        {
            return model.Map<Transaction, TransactionInquiryViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Transaction, TransactionInquiryViewModel>()
                .ForMember(x => x.AccountId, y => y.MapFrom(x => x.Account.Id))
                .ForMember(x => x.AccountName, y => y.MapFrom(x => x.Account.AccountName))
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Account.Branch.Id))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Account.Branch.BranchName))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Account.Branch.Company.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.Account.Branch.Company.Name))
                .ForMember(x => x.TransactionId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Description, y => y.MapFrom(x => x.TransactionDescription))
                .ForMember(x => x.Credit, y => y.MapFrom(x => x.TransactionType==true ? x.Amount : 0))
                .ForMember(x => x.Debit, y => y.MapFrom(x => x.TransactionType == true ? 0 : x.Amount));
            }).MapAuditableFields<TransactionInquiryViewModel>(model);

        }
        public static TransactionViewModel ToViewModel(this Transaction model)
        {
            return model.Map<Transaction, TransactionViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Transaction, TransactionViewModel>()
                .ForMember(x => x.AccountName, y => y.MapFrom(x => x.Account.AccountName))
                .ForMember(x => x.TransactionId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.TransactionType, y => y.MapFrom(x => x.TransactionType));
            }).MapAuditableFields<TransactionViewModel>(model);

        }

        public static LedgerViewModel ToLedgerViewModel(this Transaction model)
        {
            return model.Map<Transaction, LedgerViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Transaction, LedgerViewModel>()
                .ForMember(x => x.AccountId, y => y.MapFrom(x => x.Account.Id))
                .ForMember(x => x.TransactionDate, y => y.MapFrom(x => x.CreatedOn))
                .ForMember(x => x.Credit, y => y.MapFrom(x => x.TransactionType == true ? x.Amount : 0))
                .ForMember(x => x.TransactionDescription, y=> y.MapFrom(x => x.TransactionDescription))
                .ForMember(x => x.Debit, y => y.MapFrom(x => x.TransactionType == true ? 0 : x.Amount));
            }).MapAuditableFields<LedgerViewModel>(model);

        }


        //public static TrialBalanceViewModel ToTrialBalanceViewModel(this Transaction model)
        //{
        //    return model.Map<Transaction, TrialBalanceViewModel>(delegate (IMapperConfigurationExpression cfg) {
        //        cfg.CreateMap<Transaction, TrialBalanceViewModel>()
        //        .ForMember(x => x.AccountId, y => y.MapFrom(x => x.Account.Id))
        //        .ForMember(x => x.AccountTitle, y => y.MapFrom(x => x.Account.AccountName))
        //        .ForMember(x => x.TransactionDescription, y => y.MapFrom(x => x.TransactionDescription))
        //        .ForMember(x => x.Debit, y => y.MapFrom(x => x.TransactionType == true ? 0 : x.Amount));
        //    }).MapAuditableFields<TrialBalanceViewModel>(model);

        //}
    }
}

