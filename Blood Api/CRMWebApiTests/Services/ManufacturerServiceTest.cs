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
    public class ManufacturerServiceTests
    {



        [TestMethod()]
        public void CreateManufacturerTest()
        {
            ManufacturerService ManufacturerService = new ManufacturerService();
            ManufacturerBindingModel model = new ManufacturerBindingModel
            {
                ManufacturerName = "New Manufacturer1",
                Description = "DGK Manufacturer1",
                DisplayOrder = 1,
                ManufacturerImageUpload = "XYZManufacturerImage"
            };

            int userId = 1;
            var newuser = ManufacturerService.CreateManufacturer(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}