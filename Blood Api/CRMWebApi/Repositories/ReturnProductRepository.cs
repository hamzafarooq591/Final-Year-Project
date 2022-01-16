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
    
    public class ReturnProductRepository : Repository<ReturnProduct>, IReturnProductRepository, IRepository<ReturnProduct>
    {
        public ReturnProductRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<ReturnProduct> Filter(int rows, int pageNumber)
        {
            var result = NashContext.ReturnProducts
                .Include(x => x.Product)
                .Include(x => x.Customer.Account.Branch)
                .Include(x => x.Customer)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<ReturnProduct>(pageNumber, rows);
        }
         
        public ReturnProductViewModel FindOneMapped(int ReturnProductId) =>
            this.FindOne(ReturnProductId).FirstOrDefault<ReturnProduct>().ToViewModel();

        public IQueryable<ReturnProduct> FindOne(int ReturnProductId)
        {
            return NashContext.ReturnProducts
                .Include(x => x.Product)
                .Include(x => x.Customer.Account.Branch)
                .Include(x => x.Customer)
                .Where(x => x.Id == ReturnProductId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

