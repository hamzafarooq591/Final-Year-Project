namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IPurchaseDeliveryService
    {
        PurchaseDeliveryViewModel CreatePurchaseDelivery(PurchaseDeliveryBindingModel model, int userId);
        bool DeletePurchaseDelivery(int PurchaseDeliveryId);
        PurchaseDeliveryViewModel GetPurchaseDeliveryByPurchaseDeliveryId(int PurchaseDeliveryId);
        NashPagedList<PurchaseDeliveryViewModel> GetPurchaseDelivery(int rows, int pageNumber);
        PurchaseDeliveryViewModel UpdatePurchaseDelivery(PurchaseDeliveryBindingModel model, int userId);
    }
}

