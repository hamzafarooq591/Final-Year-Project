namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        CustomerViewModel CreateCustomer(CustomerBindingModel model, int userId);
        bool DeleteCustomer(int CustomerId);
        CustomerViewModel GetCustomerByCustomerId(int CustomerId);
        NashPagedList<CustomerViewModel> GetCustomer(int rows, int pageNumber, bool? isTransporter = null);
        CustomerViewModel UpdateCustomer(CustomerBindingModel model, int userId);
    }
}

