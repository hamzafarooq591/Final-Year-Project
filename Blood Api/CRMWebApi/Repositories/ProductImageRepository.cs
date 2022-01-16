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
    
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository, IRepository<ProductImage>
    {
        public ProductImageRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<ProductImage> Filter(int rows, int pageNumber , string SearchString ="")
        {
            var result = NashContext.ProductImages
                .Include(x => x.ProductImageUpload)
                .Include(x => x.Product)
               .Where(x =>  x.IsDeleted == false && (SearchString==""));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<ProductImage>(pageNumber, rows);
        }
         
        public ProductImageViewModel FindOneMapped(int ProductImageId) =>
            this.FindOne(ProductImageId).FirstOrDefault<ProductImage>().ToViewModel();

        public IQueryable<ProductImage> FindOne(int ProductImageId)
        {
            return NashContext.ProductImages
                .Include(x => x.ProductImageUpload)
                .Include(x => x.Product)
                .Where(x => x.Id == ProductImageId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

