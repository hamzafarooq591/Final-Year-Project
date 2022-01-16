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
    
    public class VendorPurchaseOrderRepository : Repository<VendorPurchaseOrder>, IVendorPurchaseOrderRepository, IRepository<VendorPurchaseOrder>
    {
        public VendorPurchaseOrderRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<VendorPurchaseOrder> Filter(int rows, int pageNumber)
        {
            var result = NashContext.VendorPurchaseOrders
                .Include(x => x.Vendor)
                .Include(x => x.Company)
                .Include(x => x.InvoiceImage)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<VendorPurchaseOrder>(pageNumber, rows);
        }
         
        public VendorPurchaseOrderViewModel FindOneMapped(int VendorPurchaseOrderId) =>
            this.FindOne(VendorPurchaseOrderId).FirstOrDefault<VendorPurchaseOrder>().ToViewModel();

        public IQueryable<VendorPurchaseOrder> FindOne(int VendorPurchaseOrderId)
        {
            return NashContext.VendorPurchaseOrders
                .Include(x => x.Vendor)
                .Include(x => x.Company)
                .Include(x => x.InvoiceImage)
                .Where(x => x.Id == VendorPurchaseOrderId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

