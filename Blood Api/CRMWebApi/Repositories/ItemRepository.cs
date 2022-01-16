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
    
    public class ItemRepository : Repository<Item>, IItemRepository, IRepository<Item>
    {
        public ItemRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Item> Filter(int rows, int pageNumber)
        {
            var result = NashContext.Items
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Item>(pageNumber, rows);
        }
         
        public ItemViewModel FindOneMapped(int ItemId) =>
            this.FindOne(ItemId).FirstOrDefault<Item>().ToViewModel();

        public IQueryable<Item> FindOne(int ItemId)
        {
            return NashContext.Items
                .Where(x => x.Id == ItemId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

