namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IWPQuantityService
    {
        WPQuantityViewModel CreateWPQuantity(WPQuantityBindingModel model, int userId);
        bool DeleteWPQuantity(int WPQuantityId);
        WPQuantityViewModel GetWPQuantityByWPQuantityId(int WPQuantityId);
        NashPagedList<WPQuantityViewModel> GetWPQuantity(int rows, int pageNumber);
        WPQuantityViewModel UpdateWPQuantity(WPQuantityBindingModel model, int userId);
    }
}

