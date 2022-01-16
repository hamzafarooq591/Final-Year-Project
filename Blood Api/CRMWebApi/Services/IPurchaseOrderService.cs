namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IPurchaseOrderService
    {
        PurchaseOrderViewModel CreatePurchaseOrder(PurchaseOrderBindingModel model, int userId);
        bool DeletePurchaseOrder(int PurchaseOrderId);
        PurchaseOrderViewModel GetPurchaseOrderByPurchaseOrderId(int PurchaseOrderId);
        NashPagedList<PurchaseOrderViewModel> GetPurchaseOrder(int rows, int pageNumber, bool? isCompleted = null);
        PurchaseOrderViewModel UpdatePurchaseOrder(PurchaseOrderBindingModel model, int userId);
    }
}

