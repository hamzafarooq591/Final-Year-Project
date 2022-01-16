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

    public static class CustomerMapper
    {
        public static Customer ToEntity(this CustomerBindingModel model, int userId, Customer original = null)
        {
            bool flag = original != null;
            Customer company = flag ? model.Map<CustomerBindingModel, Customer>(original) : model.Map<CustomerBindingModel, Customer>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Customer>(userId);
            }
            return company.MapLastModifiedFields<Customer>(userId);
        }
        public static NashPagedList<CustomerViewModel> ToViewModel(this IPagedList<Customer> models)
        {
            List<CustomerViewModel> viewModels = new List<CustomerViewModel>();
            models.ToList<Customer>().ForEach(delegate (Customer a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<CustomerViewModel>(models.GetMetaData());
        }
        public static CustomerViewModel ToViewModel(this Customer model)
        {
            return model.Map<Customer, CustomerViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Customer, CustomerViewModel>()
                .ForMember(x => x.AccountId, y => y.MapFrom(x => x.Account.Id))
                .ForMember(x => x.AccountName, y => y.MapFrom(x => x.Account.AccountName))
                .ForMember(x => x.CustomerId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<CustomerViewModel>(model);

        }
    }
}

