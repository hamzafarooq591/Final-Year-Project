namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IWarrantyService
    {
        WarrantyViewModel CreateWarranty(WarrantyBindingModel model, int userId);
        bool DeleteWarranty(int WarrantyId);
        WarrantyViewModel GetWarrantyByWarrantyId(int WarrantyId);
        NashPagedList<WarrantyViewModel> GetWarranty(int rows, int pageNumber);
        WarrantyViewModel UpdateWarranty(WarrantyBindingModel model, int userId);
    }
}

