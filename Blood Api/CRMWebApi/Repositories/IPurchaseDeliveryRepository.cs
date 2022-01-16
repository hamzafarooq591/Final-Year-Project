namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPurchaseDeliveryRepository : IRepository<PurchaseDelivery>
    {
        IPagedList<PurchaseDelivery> Filter(int rows, int pageNumber);
        IQueryable<PurchaseDelivery> FindOne(int PurchaseDeliveryId);
        PurchaseDeliveryViewModel FindOneMapped(int PurchaseDeliveryId);
    }
}

