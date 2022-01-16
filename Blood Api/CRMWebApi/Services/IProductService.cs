namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IProductService
    {
        ProductViewModel CreateProduct(ProductBindingModel model, int userId);
        bool DeleteProduct(int ProductId);
        ProductViewModel GetProductByProductId(int ProductId);
        NashPagedList<ProductViewModel> GetProduct(int rows, int pageNumber , string SearchString = "");
        ProductViewModel UpdateProduct(ProductBindingModel model, int userId);
    }
}

