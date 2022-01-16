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

    public static class BankAccountMapper
    {
        public static BankAccount ToEntity(this BankAccountBindingModel model, int userId, BankAccount original = null)
        {
            bool flag = original != null;
            BankAccount company = flag ? model.Map<BankAccountBindingModel, BankAccount>(original) : model.Map<BankAccountBindingModel, BankAccount>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<BankAccount>(userId);
            }
            return company.MapLastModifiedFields<BankAccount>(userId);
        }
        public static NashPagedList<BankAccountViewModel> ToViewModel(this IPagedList<BankAccount> models)
        {
            List<BankAccountViewModel> viewModels = new List<BankAccountViewModel>();
            models.ToList<BankAccount>().ForEach(delegate (BankAccount a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<BankAccountViewModel>(models.GetMetaData());
        }
        public static BankAccountViewModel ToViewModel(this BankAccount model)
        {
            return model.Map<BankAccount, BankAccountViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<BankAccount, BankAccountViewModel>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.Company.Name))
                .ForMember(x => x.BankAccountId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.BankName, y => y.MapFrom(x => x.Bank.BankName))
                .ForMember(x => x.BankId, y => y.MapFrom(x => x.Bank.Id));
            }).MapAuditableFields<BankAccountViewModel>(model);

        }
    }
}

