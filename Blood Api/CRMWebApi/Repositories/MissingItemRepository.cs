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
    
    public class MissingItemRepository : Repository<MissingItem>, IMissingItemRepository, IRepository<MissingItem>
    {
        public MissingItemRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<MissingItem> Filter(int rows, int pageNumber)
        {
            var result = NashContext.MissingItems
                .Include(x => x.Branch)
                .Include(x => x.Product)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<MissingItem>(pageNumber, rows);
        }
         
        public MissingItemViewModel FindOneMapped(int MissingItemId) =>
            this.FindOne(MissingItemId).FirstOrDefault<MissingItem>().ToViewModel();

        public IQueryable<MissingItem> FindOne(int MissingItemId)
        {
            return NashContext.MissingItems
                .Include(x => x.Branch)
                .Include(x => x.Product)
                .Where(x => x.Id == MissingItemId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

