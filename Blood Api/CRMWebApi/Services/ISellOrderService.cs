namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ISellOrderService
    {
        SellOrderViewModel CreateSellOrder(SellOrderBindingModel model, int userId);
        bool DeleteSellOrder(int SellOrderId);
        SellOrderViewModel GetSellOrderBySellOrderId(int SellOrderId);
        NashPagedList<SellOrderViewModel> GetSellOrder(int rows, int pageNumber, bool? isCompleted = null);
        SellOrderViewModel UpdateSellOrder(SellOrderBindingModel model, int userId);
    }
}

