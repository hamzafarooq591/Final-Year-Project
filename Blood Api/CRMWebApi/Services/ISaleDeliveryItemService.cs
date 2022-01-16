namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ISaleDeliveryItemService
    {
        SaleDeliveryItemViewModel CreateSaleDeliveryItem(SaleDeliveryItemBindingModel model, int userId);
        bool DeleteSaleDeliveryItem(int SaleDeliveryItemId);
        SaleDeliveryItemViewModel GetSaleDeliveryItemBySaleDeliveryItemId(int SaleDeliveryItemId);
        NashPagedList<SaleDeliveryItemViewModel> GetSaleDeliveryItemBySaleDeliveryId(int rows, int pageNumber, int SaleDeliveryId);
        NashPagedList<SaleDeliveryItemViewModel> GetSaleDeliveryItem(int rows, int pageNumber, bool? isCompleted = null);
        SaleDeliveryItemViewModel UpdateSaleDeliveryItem(SaleDeliveryItemBindingModel model, int userId);
    }
}

