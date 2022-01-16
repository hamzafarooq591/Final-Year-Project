namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IInventoryRequestService
    {
        InventoryRequestViewModel CreateInventoryRequest(InventoryRequestBindingModel model, int userId);
        bool DeleteInventoryRequest(int InventoryRequestId);
        InventoryRequestViewModel GetInventoryRequestByInventoryRequestId(int InventoryRequestId);
        NashPagedList<InventoryRequestViewModel> GetInventoryRequest(int rows, int pageNumber);
        InventoryRequestViewModel UpdateInventoryRequest(InventoryRequestBindingModel model, int userId);
    }
}

