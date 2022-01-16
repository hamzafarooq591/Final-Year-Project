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
    
    public class ProductWarrantyRepository : Repository<ProductWarranty>, IProductWarrantyRepository, IRepository<ProductWarranty>
    {
        public ProductWarrantyRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<ProductWarranty> Filter(int rows, int pageNumber)
        {
            var result = NashContext.ProductWarranties
                .Include(x => x.Product)
                .Include(x => x.WarrantyMode)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<ProductWarranty>(pageNumber, rows);
        }
         
        public ProductWarrantyViewModel FindOneMapped(int ProductWarrantyId) =>
            this.FindOne(ProductWarrantyId).FirstOrDefault<ProductWarranty>().ToViewModel();

        public IQueryable<ProductWarranty> FindOne(int ProductWarrantyId)
        {
            return NashContext.ProductWarranties
                .Include(x => x.Product)
                .Include(x => x.WarrantyMode)
                .Where(x => x.Id == ProductWarrantyId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

