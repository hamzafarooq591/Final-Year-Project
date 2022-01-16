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

    public static class VendorPurchaseOrderMapper
    {
        public static VendorPurchaseOrder ToEntity(this VendorPurchaseOrderBindingModel model, int userId, VendorPurchaseOrder original = null)
        {
            bool flag = original != null;
            VendorPurchaseOrder company = flag ? model.Map<VendorPurchaseOrderBindingModel, VendorPurchaseOrder>(original) : model.Map<VendorPurchaseOrderBindingModel, VendorPurchaseOrder>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<VendorPurchaseOrder>(userId);
            }
            return company.MapLastModifiedFields<VendorPurchaseOrder>(userId);
        }
        public static NashPagedList<VendorPurchaseOrderViewModel> ToViewModel(this IPagedList<VendorPurchaseOrder> models)
        {
            List<VendorPurchaseOrderViewModel> viewModels = new List<VendorPurchaseOrderViewModel>();
            models.ToList<VendorPurchaseOrder>().ForEach(delegate (VendorPurchaseOrder a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<VendorPurchaseOrderViewModel>(models.GetMetaData());
        }
        public static VendorPurchaseOrderViewModel ToViewModel(this VendorPurchaseOrder model)
        {
            return model.Map<VendorPurchaseOrder, VendorPurchaseOrderViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<VendorPurchaseOrder, VendorPurchaseOrderViewModel>()
                .ForMember(x => x.VendorId, y => y.MapFrom(x => x.Vendor.Id))
                .ForMember(x => x.VendorName, y => y.MapFrom(x => x.Vendor.VendorName))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.Company.Name))
                .ForMember(x => x.ImageUploadId, y => y.MapFrom(x => x.InvoiceImage.Id))
                .ForMember(x => x.VendorPurchaseOrderId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<VendorPurchaseOrderViewModel>(model);

        }
    }
}

