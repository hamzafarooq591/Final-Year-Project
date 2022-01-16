namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ISaleDeliveryService
    {
        SaleDeliveryViewModel CreateSaleDelivery(SaleDeliveryBindingModel model, int userId);
        bool DeleteSaleDelivery(int SaleDeliveryId);
        SaleDeliveryViewModel GetSaleDeliveryBySaleDeliveryId(int SaleDeliveryId);
        NashPagedList<SaleDeliveryViewModel> GetSaleDelivery(int rows, int pageNumber);
        SaleDeliveryViewModel UpdateSaleDelivery(SaleDeliveryBindingModel model, int userId);
    }
}

