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
    
    public class SellOrderRepository : Repository<SellOrder>, ISellOrderRepository, IRepository<SellOrder>
    {
        public SellOrderRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<SellOrder> Filter(int rows, int pageNumber, bool? isCompleted = null)
        {
            var result = NashContext.SellOrders
                .Include(x => x.Party)
                .Include(x => x.Party.Account)
                .Include(x => x.Item)
               .Where(x =>  x.IsDeleted == false && (x.isCompleted == isCompleted || isCompleted == null));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<SellOrder>(pageNumber, rows);
        }
         
        public SellOrderViewModel FindOneMapped(int SellOrderId) =>
            this.FindOne(SellOrderId).FirstOrDefault<SellOrder>().ToViewModel();

        public IQueryable<SellOrder> FindOne(int SellOrderId)
        {
            return NashContext.SellOrders
                 .Include(x => x.Party)
                 .Include(x => x.Party.Account)
                .Include(x => x.Item)
                .Where(x => x.Id == SellOrderId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

