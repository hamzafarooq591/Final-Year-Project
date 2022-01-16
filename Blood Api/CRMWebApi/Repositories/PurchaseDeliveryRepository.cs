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
    
    public class PurchaseDeliveryRepository : Repository<PurchaseDelivery>, IPurchaseDeliveryRepository, IRepository<PurchaseDelivery>
    {
        public PurchaseDeliveryRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<PurchaseDelivery> Filter(int rows, int pageNumber)
        {
            var result = NashContext.PurchaseDeliveries
                .Include(x => x.PurchaseOrder)
                .Include(x => x.SaleDelivery)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<PurchaseDelivery>(pageNumber, rows);
        }
         
        public PurchaseDeliveryViewModel FindOneMapped(int PurchaseDeliveryId) =>
            this.FindOne(PurchaseDeliveryId).FirstOrDefault<PurchaseDelivery>().ToViewModel();

        public IQueryable<PurchaseDelivery> FindOne(int PurchaseDeliveryId)
        {
            return NashContext.PurchaseDeliveries
                .Include(x => x.PurchaseOrder)
                .Include(x => x.SaleDelivery)
                .Where(x => x.Id == PurchaseDeliveryId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

