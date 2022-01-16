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

    public static class OrderMapper
    {
        public static Order ToEntity(this OrderBindingModel model, int userId, Order original = null)
        {
            bool flag = original != null;
            Order company = flag ? model.Map<OrderBindingModel, Order>(original) : model.Map<OrderBindingModel, Order>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Order>(userId);
            }
            return company.MapLastModifiedFields<Order>(userId);
        }
        public static NashPagedList<OrderViewModel> ToViewModel(this IPagedList<Order> models)
        {
            List<OrderViewModel> viewModels = new List<OrderViewModel>();
            models.ToList<Order>().ForEach(delegate (Order a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<OrderViewModel>(models.GetMetaData());
        }
        public static OrderViewModel ToViewModel(this Order model)
        {
            return model.Map<Order, OrderViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Order, OrderViewModel>()
                .ForMember(x => x.InvoiceId, y => y.MapFrom(x => x.Invoice.Id))
                .ForMember(x => x.InvoiceCode, y => y.MapFrom(x => x.Invoice.InvoiceNo))
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.ProductName))
                .ForMember(x => x.OrderStatusId, y => y.MapFrom(x => x.Approval.Id))
                .ForMember(x => x.OrderStatusTitle, y => y.MapFrom(x => x.Approval.ApprovalTitle))
                .ForMember(x => x.CustomerId, y => y.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.CustomerName, y => y.MapFrom(x => x.Customer.CustomerName))
                .ForMember(x => x.OrderId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.NashUser.Branch.Id))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.NashUser.Branch.BranchName))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.NashUser.Branch.Company.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.NashUser.Branch.Company.Name))
                .ForMember(x => x.NashUserId, y => y.MapFrom(x => x.NashUser.Id));
            }).MapAuditableFields<OrderViewModel>(model);

        }
    }
}

