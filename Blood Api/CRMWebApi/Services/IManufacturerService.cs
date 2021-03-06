namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IManufacturerService
    {
        ManufacturerViewModel CreateManufacturer(ManufacturerBindingModel model, int userId);
        bool DeleteManufacturer(int manufacturerId);
        ManufacturerViewModel GetManufacturerByManufacturerId(int manufacturerId);
        NashPagedList<ManufacturerViewModel> GetManufacturer(int rows, int pageNumber , string SearchString = "");
        ManufacturerViewModel UpdateManufacturer(ManufacturerBindingModel model, int userId);
    }
}

