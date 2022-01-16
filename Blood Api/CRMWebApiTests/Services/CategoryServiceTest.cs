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
    public class CategoryServiceTests
    {



        [TestMethod()]
        public void CreateCategoryTest()
        {
            CategoryService CategoryService = new CategoryService();
            ManufacturerService manufacturerService = new ManufacturerService();
            CategoryBindingModel model = new CategoryBindingModel
            {
                CategoryName = "New Category1",
                CategoryDescription = "DGK Category1",
                CategoryImageUpload = "New Category Image",
                ImageId = 2,
                ManufacturerId = manufacturerService.GetManufacturer(1, 1, "").Data[0].ManufacturerId,
                IsActive = true,
                IsPublished = false,
                IsShowOnHomePage = true
                
            };

            int userId = 1;
            var newuser = CategoryService.CreateCategory(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}