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

    public static class InventoryRequestMapper
    {
        public static InventoryRequest ToEntity(this InventoryRequestBindingModel model, int userId, InventoryRequest original = null)
        {
            bool flag = original != null;
            InventoryRequest company = flag ? model.Map<InventoryRequestBindingModel, InventoryRequest>(original) : model.Map<InventoryRequestBindingModel, InventoryRequest>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<InventoryRequest>(userId);
            }
            return company.MapLastModifiedFields<InventoryRequest>(userId);
        }
        public static NashPagedList<InventoryRequestViewModel> ToViewModel(this IPagedList<InventoryRequest> models)
        {
            List<InventoryRequestViewModel> viewModels = new List<InventoryRequestViewModel>();
            models.ToList<InventoryRequest>().ForEach(delegate (InventoryRequest a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<InventoryRequestViewModel>(models.GetMetaData());
        }
        public static InventoryRequestViewModel ToViewModel(this InventoryRequest model)
        {
            return model.Map<InventoryRequest, InventoryRequestViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<InventoryRequest, InventoryRequestViewModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Branch.Id))
                .ForMember(x => x.InventoryRequestId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<InventoryRequestViewModel>(model);

        }
    }
}

