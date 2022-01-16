namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IProductImageService
    {
        ProductImageViewModel CreateProductImage(ProductImageBindingModel model, int userId);
        bool DeleteProductImage(int ProductImageId);
        ProductImageViewModel GetProductImageByProductImageId(int ProductImageId);
        NashPagedList<ProductImageViewModel> GetProductImage(int rows, int pageNumber, string SearchString = "");
        ProductImageViewModel UpdateProductImage(ProductImageBindingModel model, int userId);

    }
}

