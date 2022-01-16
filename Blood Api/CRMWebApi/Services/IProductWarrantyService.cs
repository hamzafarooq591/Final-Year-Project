namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IProductWarrantyService
    {
        ProductWarrantyViewModel CreateProductWarranty(ProductWarrantyBindingModel model, int userId);
        bool DeleteProductWarranty(int ProductWarrantyId);
        ProductWarrantyViewModel GetProductWarrantyByProductWarrantyId(int ProductWarrantyId);
        NashPagedList<ProductWarrantyViewModel> GetProductWarranty(int rows, int pageNumber);
        ProductWarrantyViewModel UpdateProductWarranty(ProductWarrantyBindingModel model, int userId);
    }
}

