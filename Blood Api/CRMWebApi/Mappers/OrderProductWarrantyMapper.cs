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

    public static class OrderProductWarrantyMapper
    {
        public static OrderProductWarranty ToEntity(this OrderProductWarrantyBindingModel model, int userId, OrderProductWarranty original = null)
        {
            bool flag = original != null;
            OrderProductWarranty company = flag ? model.Map<OrderProductWarrantyBindingModel, OrderProductWarranty>(original) : model.Map<OrderProductWarrantyBindingModel, OrderProductWarranty>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<OrderProductWarranty>(userId);
            }
            return company.MapLastModifiedFields<OrderProductWarranty>(userId);
        }
        public static NashPagedList<OrderProductWarrantyViewModel> ToViewModel(this IPagedList<OrderProductWarranty> models)
        {
            List<OrderProductWarrantyViewModel> viewModels = new List<OrderProductWarrantyViewModel>();
            models.ToList<OrderProductWarranty>().ForEach(delegate (OrderProductWarranty a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<OrderProductWarrantyViewModel>(models.GetMetaData());
        }
        public static OrderProductWarrantyViewModel ToViewModel(this OrderProductWarranty model)
        {
            return model.Map<OrderProductWarranty, OrderProductWarrantyViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<OrderProductWarranty, OrderProductWarrantyViewModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.ProductName))
                .ForMember(x => x.OrderProductWarrantyId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.OrderId, y => y.MapFrom(x => x.Order.Id))
                .ForMember(x => x.InvoiceNo, y => y.MapFrom(x => x.Order.Invoice));
            }).MapAuditableFields<OrderProductWarrantyViewModel>(model);

        }
    }
}

