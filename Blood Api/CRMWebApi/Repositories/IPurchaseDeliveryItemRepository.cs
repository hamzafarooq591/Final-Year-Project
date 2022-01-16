namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPurchaseDeliveryItemRepository : IRepository<PurchaseDeliveryItem>
    {
        IPagedList<PurchaseDeliveryItem> Filter(int rows, int pageNumber, bool? isCompleted = null);
        IQueryable<PurchaseDeliveryItem> FindOne(int PurchaseDeliveryItemId);
        PurchaseDeliveryItemViewModel FindOneMapped(int PurchaseDeliveryItemId);
        IPagedList<PurchaseDeliveryItem> FilterByPurchaseDeliveryId(int rows, int pageNumber, int PurchaseDeliveryId);
    }
}

