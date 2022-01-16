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
    
    public class WPQuantityRepository : Repository<WPQuantity>, IWPQuantityRepository, IRepository<WPQuantity>
    {
        public WPQuantityRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<WPQuantity> Filter(int rows, int pageNumber)
        {
            var result = NashContext.WPQuantities
                .Include(x => x.Warehouse)
                .Include(x => x.Product)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<WPQuantity>(pageNumber, rows);
        }
         
        public WPQuantityViewModel FindOneMapped(int WPQuantityId) =>
            this.FindOne(WPQuantityId).FirstOrDefault<WPQuantity>().ToViewModel();

        public IQueryable<WPQuantity> FindOne(int WPQuantityId)
        {
            return NashContext.WPQuantities
                .Include(x => x.Warehouse)
                .Include(x => x.Product)
                .Where(x => x.Id == WPQuantityId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

