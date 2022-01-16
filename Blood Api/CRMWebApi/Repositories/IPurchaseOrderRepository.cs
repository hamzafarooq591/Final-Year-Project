namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPurchaseOrderRepository : IRepository<PurchaseOrder>
    {
        IPagedList<PurchaseOrder> Filter(int rows, int pageNumber, bool? isCompleted = null);
        IQueryable<PurchaseOrder> FindOne(int PurchaseOrderId);
        PurchaseOrderViewModel FindOneMapped(int PurchaseOrderId);
    }
}

