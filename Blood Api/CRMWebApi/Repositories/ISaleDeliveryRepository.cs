namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ISaleDeliveryRepository : IRepository<SaleDelivery>
    {
        IPagedList<SaleDelivery> Filter(int rows, int pageNumber);
        IQueryable<SaleDelivery> FindOne(int SaleDeliveryId);
        SaleDeliveryViewModel FindOneMapped(int SaleDeliveryId);
    }
}

