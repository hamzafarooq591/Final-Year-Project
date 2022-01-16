namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IVendorPurchaseOrderRepository : IRepository<VendorPurchaseOrder>
    {
        IPagedList<VendorPurchaseOrder> Filter(int rows, int pageNumber);
        IQueryable<VendorPurchaseOrder> FindOne(int VendorPurchaseOrderId);
        VendorPurchaseOrderViewModel FindOneMapped(int VendorPurchaseOrderId);
    }
}

