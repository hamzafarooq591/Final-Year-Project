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

    public static class B2BTransferMapper
    {
        public static B2BTransfer ToEntity(this B2BTransferBindingModel model, int userId, B2BTransfer original = null)
        {
            bool flag = original != null;
            B2BTransfer company = flag ? model.Map<B2BTransferBindingModel, B2BTransfer>(original) : model.Map<B2BTransferBindingModel, B2BTransfer>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<B2BTransfer>(userId);
            }
            return company.MapLastModifiedFields<B2BTransfer>(userId);
        }
        public static NashPagedList<B2BTransferViewModel> ToViewModel(this IPagedList<B2BTransfer> models)
        {
            List<B2BTransferViewModel> viewModels = new List<B2BTransferViewModel>();
            models.ToList<B2BTransfer>().ForEach(delegate (B2BTransfer a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<B2BTransferViewModel>(models.GetMetaData());
        }
        public static B2BTransferViewModel ToViewModel(this B2BTransfer model)
        {
            return model.Map<B2BTransfer, B2BTransferViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<B2BTransfer, B2BTransferViewModel>()
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Branch.Id))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Branch.BranchName))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Branch.Company.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.Branch.Company.Name))
                .ForMember(x => x.B2BTransferId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.FromBankAccountId, y => y.MapFrom(x => x.FromBankAccount.Id))
                .ForMember(x => x.FromBankAccountName, y => y.MapFrom(x => x.FromBankAccount.AccountTitle))
                .ForMember(x => x.ToBankAccountId, y => y.MapFrom(x => x.ToBankAccount.Id))
                .ForMember(x => x.ToBankAccountName, y => y.MapFrom(x => x.ToBankAccount.AccountTitle));
            }).MapAuditableFields<B2BTransferViewModel>(model);

        }
    }
}

