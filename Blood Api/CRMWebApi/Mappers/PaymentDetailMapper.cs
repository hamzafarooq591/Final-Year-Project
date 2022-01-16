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

    public static class PaymentDetailMapper
    {
        public static PaymentDetail ToEntity(this PaymentDetailBindingModel model, int userId, PaymentDetail original = null)
        {
            bool flag = original != null;
            PaymentDetail company = flag ? model.Map<PaymentDetailBindingModel, PaymentDetail>(original) : model.Map<PaymentDetailBindingModel, PaymentDetail>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<PaymentDetail>(userId);
            }
            return company.MapLastModifiedFields<PaymentDetail>(userId);
        }
        public static NashPagedList<PaymentDetailViewModel> ToViewModel(this IPagedList<PaymentDetail> models)
        {
            List<PaymentDetailViewModel> viewModels = new List<PaymentDetailViewModel>();
            models.ToList<PaymentDetail>().ForEach(delegate (PaymentDetail a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PaymentDetailViewModel>(models.GetMetaData());
        }
        public static PaymentDetailViewModel ToViewModel(this PaymentDetail model)
        {
            return model.Map<PaymentDetail, PaymentDetailViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<PaymentDetail, PaymentDetailViewModel>()
                .ForMember(x => x.PayToTypeId, y => y.MapFrom(x => x.PayToType.Id))
                .ForMember(x => x.PaytoTypeTitle, y => y.MapFrom(x => x.PayToType.Title))
                .ForMember(x => x.PaymentTypeId, y => y.MapFrom(x => x.PaymentType.Id))
                .ForMember(x => x.PaymentTypeTitle, y => y.MapFrom(x => x.PaymentType.Title))
                .ForMember(x => x.PaymentStatusId, y => y.MapFrom(x => x.PaymentStatus.Id))
                .ForMember(x => x.PaymentStatusTitle, y => y.MapFrom(x => x.PaymentStatus.ApprovalTitle))
                .ForMember(x => x.BankAccountId, y => y.MapFrom(x => x.BankAccount.Id))
                .ForMember(x => x.BankAccountTitle, y => y.MapFrom(x => x.BankAccount.AccountTitle))
                .ForMember(x => x.ImageProofId, y => y.MapFrom(x => x.ImageProof.Id))
                .ForMember(x => x.CustomerId, y => y.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.CustomerName, y => y.MapFrom(x => x.Customer.CustomerName))
                .ForMember(x => x.PaymentDetailId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<PaymentDetailViewModel>(model);

        }
    }
}

