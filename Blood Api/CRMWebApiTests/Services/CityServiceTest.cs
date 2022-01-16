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
    public class CityServiceTests
    {



        [TestMethod()]
        public void CreateCityTest()
        {
            LookUpService cityService = new LookUpService();
            CityBindingModel model = new CityBindingModel
            {
                CityName = "New City1",
                CityCode = "City1 Code 32200",
                phoneCode = "Phone Code 064",
                GeoLocationId = cityService.GetGeoLocations(1, 1).Data[0].GeoLocationId.Value
            };

            int userId = 1;
            var newuser = cityService.CreateCity(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}