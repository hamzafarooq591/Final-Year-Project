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

    public static class ImportPaymentMapper
    {
        public static ImportPayment ToEntity(this ImportPaymentBindingModel model, int userId, ImportPayment original = null)
        {
            bool flag = original != null;
            ImportPayment company = flag ? model.Map<ImportPaymentBindingModel, ImportPayment>(original) : model.Map<ImportPaymentBindingModel, ImportPayment>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<ImportPayment>(userId);
            }
            return company.MapLastModifiedFields<ImportPayment>(userId);
        }
        public static NashPagedList<ImportPaymentViewModel> ToViewModel(this IPagedList<ImportPayment> models)
        {
            List<ImportPaymentViewModel> viewModels = new List<ImportPaymentViewModel>();
            models.ToList<ImportPayment>().ForEach(delegate (ImportPayment a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ImportPaymentViewModel>(models.GetMetaData());
        }
        public static ImportPaymentViewModel ToViewModel(this ImportPayment model)
        {
            return model.Map<ImportPayment, ImportPaymentViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<ImportPayment, ImportPaymentViewModel>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.Company.Name))
                .ForMember(x => x.CurrencyId, y => y.MapFrom(x => x.Currency.Id))
                .ForMember(x => x.CurrencyTitle, y => y.MapFrom(x => x.Currency.CurrencyName))
                .ForMember(x => x.BankAccountId, y => y.MapFrom(x => x.BankAccount.Id))
                .ForMember(x => x.BankAccountTitle, y => y.MapFrom(x => x.BankAccount.AccountTitle))
                .ForMember(x => x.PaymentTypeId, y => y.MapFrom(x => x.PaymentType.Id))
                .ForMember(x => x.PaymentTypeTitle, y => y.MapFrom(x => x.PaymentType.Title))
                .ForMember(x => x.MoneyChangerId, y => y.MapFrom(x => x.MoneyChanger.Id))
                .ForMember(x => x.MoneyChangerTitle, y => y.MapFrom(x => x.MoneyChanger.MCName))
                .ForMember(x => x.PayToTypeId, y => y.MapFrom(x => x.PayToType.Id))
                .ForMember(x => x.PayToTypeTitle, y => y.MapFrom(x => x.PayToType.Title))
                .ForMember(x => x.ImportPaymentId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<ImportPaymentViewModel>(model);

        }
    }
}

