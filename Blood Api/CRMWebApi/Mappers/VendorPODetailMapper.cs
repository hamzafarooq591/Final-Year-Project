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

    public static class VendorPODetailMapper
    {
        public static VendorPODetail ToEntity(this VendorPODetailBindingModel model, int userId, VendorPODetail original = null)
        {
            bool flag = original != null;
            VendorPODetail location = flag ? model.Map<VendorPODetailBindingModel, VendorPODetail>(original) : model.Map<VendorPODetailBindingModel, VendorPODetail>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<VendorPODetail>(userId);
            }
            return location.MapLastModifiedFields<VendorPODetail>(userId);
        }

        public static VendorPODetailViewModel ToViewModel(this VendorPODetail model)
        {

            return model.Map<VendorPODetail, VendorPODetailViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<VendorPODetail, VendorPODetailViewModel>()
                .ForMember(x => x.VendorPurchaseOrderId, y => y.MapFrom(x => x.VendorPurchaseOrder.Id))
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.ProductName))
                .ForMember(x => x.VendorPODetailId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<VendorPODetailViewModel>(model);
        }
        public static NashPagedList<VendorPODetailViewModel> ToViewModel(this IPagedList<VendorPODetail> models)
        {
            List<VendorPODetailViewModel> viewModels = new List<VendorPODetailViewModel>();
            models.ToList<VendorPODetail>().ForEach(delegate (VendorPODetail a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<VendorPODetailViewModel>(models.GetMetaData());
        }

        public static IList<VendorPODetailViewModel> ToViewModel(this IList<VendorPODetail> models)
        {
            List<VendorPODetailViewModel> viewModels = new List<VendorPODetailViewModel>();
            models.ToList<VendorPODetail>().ForEach(delegate (VendorPODetail a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

