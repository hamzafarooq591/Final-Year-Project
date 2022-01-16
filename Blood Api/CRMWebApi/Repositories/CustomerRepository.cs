namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections.Generic;
    
    public class CustomerRepository : Repository<Customer>, ICustomerRepository, IRepository<Customer>
    {
        public CustomerRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Customer> Filter(int rows, int pageNumber, bool? isTransporter = null)
        {
            var result = NashContext.Customers
                .Include(x => x.Account)
               .Where(x =>  x.IsDeleted == false && (x.isTransporter == isTransporter || isTransporter == null));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Customer>(pageNumber, rows);
        }
         
        public CustomerViewModel FindOneMapped(int CustomerId) =>
            this.FindOne(CustomerId).FirstOrDefault<Customer>().ToViewModel();

        public IQueryable<Customer> FindOne(int CustomerId)
        {
            return NashContext.Customers
                .Include(x => x.Account)
                .Where(x => x.Id == CustomerId && x.IsDeleted == false);
        }



        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

