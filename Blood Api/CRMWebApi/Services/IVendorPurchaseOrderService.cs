namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IVendorPurchaseOrderService
    {
        VendorPurchaseOrderViewModel CreateVendorPurchaseOrder(VendorPurchaseOrderBindingModel model, int userId);
        bool DeleteVendorPurchaseOrder(int VendorPurchaseOrderId);
        VendorPurchaseOrderViewModel GetVendorPurchaseOrderByVendorPurchaseOrderId(int VendorPurchaseOrderId);
        NashPagedList<VendorPurchaseOrderViewModel> GetVendorPurchaseOrder(int rows, int pageNumber);
        VendorPurchaseOrderViewModel UpdateVendorPurchaseOrder(VendorPurchaseOrderBindingModel model, int userId);
    }
}

