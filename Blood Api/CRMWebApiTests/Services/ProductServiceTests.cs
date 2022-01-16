using Microsoft.VisualStudio.TestTools.UnitTesting;
using NashWebApi.BindingModels;
using NashWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashWebApi.Services.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {



        [TestMethod()]
        public void CreateProductTest()
        {
            ProductService ProductService = new ProductService();
            ManufacturerService manufacturerService = new ManufacturerService();
            CategoryService categoryService = new CategoryService();
            ProductBindingModel model = new ProductBindingModel
            {
                ProductName = "New Product1",
                OldPrice = "DGK Product1",
                SpecialPrice = "ABCXYZ1",
                IsFeaturedProduct = true,
                MacAddressRequired = false,
                AllowCustomerReviews = true,
                DisableBuyButton = true,
                IsActive = false,
                IsPublished = true,
                IsShowOnHomePage = true,
                ProductLongDescription = "ABC",
                ProductShortDescription = "X",
                SpecialPriceEndDate = DateTime.Now,
                SpecialPriceStartDate = DateTime.Now,
                ManufacturerId = manufacturerService.GetManufacturer(1, 1, "").Data[0].ManufacturerId,
                CategoryId = categoryService.GetCategory(1, 1, "").Data[0].CategoryId,

            };

            int userId = 1;
            var newuser = ProductService.CreateProduct(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }

    }
}