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

    public static class ReturnProductMapper
    {
        public static ReturnProduct ToEntity(this ReturnProductBindingModel model, int userId, ReturnProduct original = null)
        {
            bool flag = original != null;
            ReturnProduct company = flag ? model.Map<ReturnProductBindingModel, ReturnProduct>(original) : model.Map<ReturnProductBindingModel, ReturnProduct>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<ReturnProduct>(userId);
            }
            return company.MapLastModifiedFields<ReturnProduct>(userId);
        }
        public static NashPagedList<ReturnProductViewModel> ToViewModel(this IPagedList<ReturnProduct> models)
        {
            List<ReturnProductViewModel> viewModels = new List<ReturnProductViewModel>();
            models.ToList<ReturnProduct>().ForEach(delegate (ReturnProduct a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ReturnProductViewModel>(models.GetMetaData());
        }
        public static ReturnProductViewModel ToViewModel(this ReturnProduct model)
        {
            return model.Map<ReturnProduct, ReturnProductViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<ReturnProduct, ReturnProductViewModel>()
                .ForMember(x => x.CustomerId, y => y.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.CustomerName, y => y.MapFrom(x => x.Customer.CustomerName))
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.ProductName))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Customer.Account.Branch.BranchName))
                .ForMember(x => x.ReturnProductId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<ReturnProductViewModel>(model);

        }
    }
}

