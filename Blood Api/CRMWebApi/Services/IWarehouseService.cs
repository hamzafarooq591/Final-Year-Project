namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IWarehouseService
    {
        WarehouseViewModel CreateWarehouse(WarehouseBindingModel model, int userId);
        bool DeleteWarehouse(int WarehouseId);
        WarehouseViewModel GetWarehouseByWarehouseId(int WarehouseId);
        NashPagedList<WarehouseViewModel> GetWarehouse(int rows, int pageNumber);
        WarehouseViewModel UpdateWarehouse(WarehouseBindingModel model, int userId);
    }
}

