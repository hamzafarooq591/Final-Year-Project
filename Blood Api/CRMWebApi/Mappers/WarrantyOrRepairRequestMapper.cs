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

    public static class WarrantyOrRepairRequestMapper
    {
        public static WarrantyOrRepairRequest ToEntity(this WarrantyOrRepairRequestBindingModel model, int userId, WarrantyOrRepairRequest original = null)
        {
            bool flag = original != null;
            WarrantyOrRepairRequest company = flag ? model.Map<WarrantyOrRepairRequestBindingModel, WarrantyOrRepairRequest>(original) : model.Map<WarrantyOrRepairRequestBindingModel, WarrantyOrRepairRequest>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<WarrantyOrRepairRequest>(userId);
            }
            return company.MapLastModifiedFields<WarrantyOrRepairRequest>(userId);
        }
        public static NashPagedList<WarrantyOrRepairRequestViewModel> ToViewModel(this IPagedList<WarrantyOrRepairRequest> models)
        {
            List<WarrantyOrRepairRequestViewModel> viewModels = new List<WarrantyOrRepairRequestViewModel>();
            models.ToList<WarrantyOrRepairRequest>().ForEach(delegate (WarrantyOrRepairRequest a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<WarrantyOrRepairRequestViewModel>(models.GetMetaData());
        }
        public static WarrantyOrRepairRequestViewModel ToViewModel(this WarrantyOrRepairRequest model)
        {
            return model.Map<WarrantyOrRepairRequest, WarrantyOrRepairRequestViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<WarrantyOrRepairRequest, WarrantyOrRepairRequestViewModel>()
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Customer.Account.Branch.BranchName))
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.WarrantyStatusId, y => y.MapFrom(x => x.WarrantyRequestStatus.Id))
                .ForMember(x => x.CustomerId, y => y.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.WarrantyOrRepairRequestId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<WarrantyOrRepairRequestViewModel>(model);

        }
    }
}

