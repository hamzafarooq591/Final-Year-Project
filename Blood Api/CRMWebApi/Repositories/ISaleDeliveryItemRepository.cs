namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ISaleDeliveryItemRepository : IRepository<SaleDeliveryItem>
    {
        IPagedList<SaleDeliveryItem> Filter(int rows, int pageNumber, bool? isCompleted = null);
        IQueryable<SaleDeliveryItem> FindOne(int SaleDeliveryItemId);
        SaleDeliveryItemViewModel FindOneMapped(int SaleDeliveryItemId);
        IPagedList<SaleDeliveryItem> FilterBySaleDeliveryId(int rows, int pageNumber, int saleDeliveryId);
        List<SaleDeliveryItem> ListBySaleDeliveryId(int saleDeliveryId);
    }
}

