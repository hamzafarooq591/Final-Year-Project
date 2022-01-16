namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ICustomerRepository : IRepository<Customer>
    {
        IPagedList<Customer> Filter(int rows, int pageNumber,bool? isTransporter = null);
        IQueryable<Customer> FindOne(int CustomerId);
        CustomerViewModel FindOneMapped(int CustomerId);
    }
}

