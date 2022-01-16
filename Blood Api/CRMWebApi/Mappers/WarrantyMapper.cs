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

    public static class WarrantyMapper
    {
        public static Warranty ToEntity(this WarrantyBindingModel model, int userId, Warranty original = null)
        {
            bool flag = original != null;
            Warranty company = flag ? model.Map<WarrantyBindingModel, Warranty>(original) : model.Map<WarrantyBindingModel, Warranty>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Warranty>(userId);
            }
            return company.MapLastModifiedFields<Warranty>(userId);
        }
        public static NashPagedList<WarrantyViewModel> ToViewModel(this IPagedList<Warranty> models)
        {
            List<WarrantyViewModel> viewModels = new List<WarrantyViewModel>();
            models.ToList<Warranty>().ForEach(delegate (Warranty a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<WarrantyViewModel>(models.GetMetaData());
        }
        public static WarrantyViewModel ToViewModel(this Warranty model)
        {
            return model.Map<Warranty, WarrantyViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Warranty, WarrantyViewModel>()
                .ForMember(x => x.OrderId, y => y.MapFrom(x => x.Order.Id))
                .ForMember(x => x.CustomerId, y => y.MapFrom(x => x.Order.Customer.Id))
                .ForMember(x => x.CustomerName, y => y.MapFrom(x => x.Order.Customer.CustomerName))
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Order.Customer.Account.Branch.Id))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Order.Customer.Account.Branch.BranchName))
                .ForMember(x => x.WarrantyModeId, y => y.MapFrom(x => x.WarrantyMode.Id))
                .ForMember(x => x.WarrantyModePeriod, y => y.MapFrom(x => x.WarrantyMode.WarrantyModePeriodInDays))
                .ForMember(x => x.WarrantyId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<WarrantyViewModel>(model);

        }
    }
}

