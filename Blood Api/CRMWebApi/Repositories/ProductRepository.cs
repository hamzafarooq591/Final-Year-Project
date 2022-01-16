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
    
    public class ProductRepository : Repository<Product>, IProductRepository, IRepository<Product>
    {
        public ProductRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Product> Filter(int rows, int pageNumber , string SearchString ="")
        {
            var result = NashContext.Products
                .Include(x => x.Category)
                .Include(x => x.WarrantyMode)
                .Include(x => x.Manufacturer)
               .Where(x =>  x.IsDeleted == false && (SearchString=="" ||x.ProductName.Contains(SearchString)));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Product>(pageNumber, rows);
        }
        ////Filler for WarrantyRequestStatus MACAddress
        //public IQueryable<Product> FindByMacAddress(string SearchString = "")
        //{
        //    return NashContext.Products
        //        .Where(x => x.IsDeleted == false && (SearchString == "" || x.ProductName.Contains(SearchString)));
        //}

        public ProductViewModel FindOneMapped(int ProductId) =>
            this.FindOne(ProductId).FirstOrDefault<Product>().ToViewModel();

        public IQueryable<Product> FindOne(int ProductId)
        {
            return NashContext.Products
                .Include(x => x.Category)
                .Include(x => x.WarrantyMode)
                .Include(x => x.Manufacturer)
                .Where(x => x.Id == ProductId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

