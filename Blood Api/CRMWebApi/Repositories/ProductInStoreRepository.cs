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
    
    public class ProductInStoreRepository : Repository<ProductInStore>, IProductInStoreRepository, IRepository<ProductInStore>
    {
        public ProductInStoreRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<ProductInStore> Filter(int rows, int pageNumber)
        {
            var result = NashContext.ProductInStores
                .Include(x => x.Branch)
                .Include(x => x.Product)
                .Include(x => x.NashUser)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<ProductInStore>(pageNumber, rows);
        }
         
        public ProductInStoreViewModel FindOneMapped(int ProductInStoreId) =>
            this.FindOne(ProductInStoreId).FirstOrDefault<ProductInStore>().ToViewModel();

        public IQueryable<ProductInStore> FindOne(int ProductInStoreId)
        {
            return NashContext.ProductInStores
                .Include(x => x.Branch)
                .Include(x => x.Product)
                .Include(x => x.NashUser)
                .Where(x => x.Id == ProductInStoreId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

