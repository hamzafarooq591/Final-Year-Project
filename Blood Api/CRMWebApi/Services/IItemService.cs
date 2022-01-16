namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IItemService
    {
        ItemViewModel CreateItem(ItemBindingModel model, int userId);
        bool DeleteItem(int ItemId);
        ItemViewModel GetItemByItemId(int ItemId);
        NashPagedList<ItemViewModel> GetItem(int rows, int pageNumber);
        ItemViewModel UpdateItem(ItemBindingModel model, int userId);
    }
}

