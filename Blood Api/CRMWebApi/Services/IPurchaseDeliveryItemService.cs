namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IPurchaseDeliveryItemService
    {
        PurchaseDeliveryItemViewModel CreatePurchaseDeliveryItem(PurchaseDeliveryItemBindingModel model, int userId);
        bool DeletePurchaseDeliveryItem(int PurchaseDeliveryItemId);
        PurchaseDeliveryItemViewModel GetPurchaseDeliveryItemByPurchaseDeliveryItemId(int PurchaseDeliveryItemId);
        NashPagedList<PurchaseDeliveryItemViewModel> GetPurchaseDeliveryItemByPurchaseDeliveryId(int rows, int pageNumber, int PurchaseDeliveryId);
        NashPagedList<PurchaseDeliveryItemViewModel> GetPurchaseDeliveryItem(int rows, int pageNumber, bool? isCompleted = null);
        PurchaseDeliveryItemViewModel UpdatePurchaseDeliveryItem(PurchaseDeliveryItemBindingModel model, int userId);
    }
}

