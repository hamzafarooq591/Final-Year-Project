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
    
    public class SaleDeliveryRepository : Repository<SaleDelivery>, ISaleDeliveryRepository, IRepository<SaleDelivery>
    {
        public SaleDeliveryRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<SaleDelivery> Filter(int rows, int pageNumber)
        {
            var result = NashContext.SaleDeliveries
                .Include(x => x.Transporter)
                .Include(x => x.PurchaseOrder)
                .Include(x => x.SellOrder)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<SaleDelivery>(pageNumber, rows);
        }
         
        public SaleDeliveryViewModel FindOneMapped(int SaleDeliveryId) =>
            this.FindOne(SaleDeliveryId).FirstOrDefault<SaleDelivery>().ToViewModel();

        public IQueryable<SaleDelivery> FindOne(int SaleDeliveryId)
        {
            return NashContext.SaleDeliveries
                 .Include(x => x.Transporter)
                .Include(x => x.PurchaseOrder)
                .Include(x => x.SellOrder)
                .Where(x => x.Id == SaleDeliveryId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

