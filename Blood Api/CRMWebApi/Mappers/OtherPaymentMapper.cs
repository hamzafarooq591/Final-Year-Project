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

    public static class OtherPaymentMapper
    {
        public static OtherPayment ToEntity(this OtherPaymentBindingModel model, int userId, OtherPayment original = null)
        {
            bool flag = original != null;
            OtherPayment company = flag ? model.Map<OtherPaymentBindingModel, OtherPayment>(original) : model.Map<OtherPaymentBindingModel, OtherPayment>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<OtherPayment>(userId);
            }
            return company.MapLastModifiedFields<OtherPayment>(userId);
        }
        public static NashPagedList<OtherPaymentViewModel> ToViewModel(this IPagedList<OtherPayment> models)
        {
            List<OtherPaymentViewModel> viewModels = new List<OtherPaymentViewModel>();
            models.ToList<OtherPayment>().ForEach(delegate (OtherPayment a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<OtherPaymentViewModel>(models.GetMetaData());
        }
        public static OtherPaymentViewModel ToViewModel(this OtherPayment model)
        {
            return model.Map<OtherPayment, OtherPaymentViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<OtherPayment, OtherPaymentViewModel>()
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Branch.Id))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Branch.BranchName))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Branch.Company.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.Branch.Company.Name))
                .ForMember(x => x.PaymentTypeId, y => y.MapFrom(x => x.PaymentType.Id))
                .ForMember(x => x.PaymentTypeTitle, y => y.MapFrom(x => x.PaymentType.Title))
                .ForMember(x => x.BankAccountId, y => y.MapFrom(x => x.BankAccount.Id))
                .ForMember(x => x.BankAccountName, y => y.MapFrom(x => x.BankAccount.AccountTitle))
                .ForMember(x => x.ImageProofId, y => y.MapFrom(x => x.ImageProof.Id))
                .ForMember(x => x.ImageProofTitle, y => y.MapFrom(x => x.ImageProof.Title))
                .ForMember(x => x.StatusId, y => y.MapFrom(x => x.Approval.Id))
                .ForMember(x => x.StatusTitle, y => y.MapFrom(x => x.Approval.ApprovalTitle))
                .ForMember(x => x.OtherPaymentId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<OtherPaymentViewModel>(model);

        }
    }
}

