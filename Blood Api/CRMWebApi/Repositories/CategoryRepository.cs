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
    
    public class CategoryRepository : Repository<Category>, ICategoryRepository, IRepository<Category>
    {
        public CategoryRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Category> Filter(int rows, int pageNumber , string SearchString ="")
        {
            var result = NashContext.Categories
                .Include(x => x.CategoryImage)
                .Include(x => x.Manufacturer)
               .Where(x =>  x.IsDeleted == false && (SearchString=="" ||x.CategoryName.Contains(SearchString)));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Category>(pageNumber, rows);
        }
         
        public CategoryViewModel FindOneMapped(int CategoryId) =>
            this.FindOne(CategoryId).FirstOrDefault<Category>().ToViewModel();

        public IQueryable<Category> FindOne(int CategoryId)
        {
            return NashContext.Categories
                .Include(x => x.CategoryImage)
                .Include(x => x.Manufacturer)
                .Where(x => x.Id == CategoryId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

