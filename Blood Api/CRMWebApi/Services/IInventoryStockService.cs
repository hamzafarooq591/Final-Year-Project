namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IInventoryStockService
    {
        InventoryStockViewModel CreateInventoryStock(InventoryStockBindingModel model, int userId);
        bool DeleteInventoryStock(int InventoryStockId);
        InventoryStockViewModel GetInventoryStockByInventoryStockId(int InventoryStockId);
        NashPagedList<InventoryStockViewModel> GetInventoryStock(int rows, int pageNumber );
        InventoryStockViewModel UpdateInventoryStock(InventoryStockBindingModel model, int userId);
    }
}

