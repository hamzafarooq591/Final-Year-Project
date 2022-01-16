namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IProductInStoreService
    {
        ProductInStoreViewModel CreateProductInStore(ProductInStoreBindingModel model, int userId);
        bool DeleteProductInStore(int ProductInStoreId);
        ProductInStoreViewModel GetProductInStoreByProductInStoreId(int ProductInStoreId);
        NashPagedList<ProductInStoreViewModel> GetProductInStore(int rows, int pageNumber);
        ProductInStoreViewModel UpdateProductInStore(ProductInStoreBindingModel model, int userId);
    }
}

