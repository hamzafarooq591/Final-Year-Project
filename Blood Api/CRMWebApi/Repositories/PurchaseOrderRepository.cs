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

    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository, IRepository<PurchaseOrder>
    {
        public PurchaseOrderRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<PurchaseOrder> Filter(int rows, int pageNumber, bool? isCompleted = null)
        {
            var result = NashContext.PurchaseOrders
                .Include(x => x.Party)
                .Include(x => x.Party.Account)
                .Include(x => x.Item)
               .Where(x => x.IsDeleted == false && (x.isCompleted == isCompleted || isCompleted == null));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<PurchaseOrder>(pageNumber, rows);
        }
         
        public PurchaseOrderViewModel FindOneMapped(int PurchaseOrderId) =>
            this.FindOne(PurchaseOrderId).FirstOrDefault<PurchaseOrder>().ToViewModel();

        public IQueryable<PurchaseOrder> FindOne(int PurchaseOrderId)
        {
            return NashContext.PurchaseOrders
                 .Include(x => x.Party)
                 .Include(x => x.Party.Account)
                .Include(x => x.Item)
                .Where(x => x.Id == PurchaseOrderId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

