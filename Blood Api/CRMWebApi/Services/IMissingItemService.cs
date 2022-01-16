namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IMissingItemService
    {
        MissingItemViewModel CreateMissingItem(MissingItemBindingModel model, int userId);
        bool DeleteMissingItem(int MissingItemId);
        MissingItemViewModel GetMissingItemByMissingItemId(int MissingItemId);
        NashPagedList<MissingItemViewModel> GetMissingItem(int rows, int pageNumber);
        MissingItemViewModel UpdateMissingItem(MissingItemBindingModel model, int userId);
    }
}

