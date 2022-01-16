namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IReturnProductService
    {
        ReturnProductViewModel CreateReturnProduct(ReturnProductBindingModel model, int userId);
        bool DeleteReturnProduct(int ReturnProductId);
        ReturnProductViewModel GetReturnProductByReturnProductId(int ReturnProductId);
        NashPagedList<ReturnProductViewModel> GetReturnProduct(int rows, int pageNumber);
        ReturnProductViewModel UpdateReturnProduct(ReturnProductBindingModel model, int userId);
    }
}

