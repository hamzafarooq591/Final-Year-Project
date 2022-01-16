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
    
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository, IRepository<Manufacturer>
    {
        public ManufacturerRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Manufacturer> Filter(int rows, int pageNumber , string SearchString ="")
        {
            var result = NashContext.Manufacturers
                .Include(x => x.ManufacturerImage)
               .Where(x =>  x.IsDeleted == false && (SearchString=="" ||x.ManufacturerName.Contains(SearchString)));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Manufacturer>(pageNumber, rows);
        }
         
        public ManufacturerViewModel FindOneMapped(int manufacturerId) =>
            this.FindOne(manufacturerId).FirstOrDefault<Manufacturer>().ToViewModel();

        public IQueryable<Manufacturer> FindOne(int manufacturerId)
        {
            return NashContext.Manufacturers
                .Include(x => x.ManufacturerImage)
                .Where(x => x.Id == manufacturerId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

