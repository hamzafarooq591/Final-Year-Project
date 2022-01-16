namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IWarrantyModeService
    {
        WarrantyModeViewModel CreateWarrantyMode(WarrantyModeBindingModel model, int userId);
        bool DeleteWarrantyMode(int WarrantyModeId);
        WarrantyModeViewModel GetWarrantyModeByWarrantyModeId(int WarrantyModeId);
        NashPagedList<WarrantyModeViewModel> GetWarrantyMode(int rows, int pageNumber );
        WarrantyModeViewModel UpdateWarrantyMode(WarrantyModeBindingModel model, int userId);
    }
}

