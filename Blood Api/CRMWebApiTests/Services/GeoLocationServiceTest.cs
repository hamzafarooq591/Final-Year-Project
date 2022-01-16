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
    public class GeoLocationServiceTests
    {



        [TestMethod()]
        public void CreateGeoLocationTest()
        {
            LookUpService GeoLocationService = new LookUpService();
            GeoLocationBindingModel model = new GeoLocationBindingModel
            {
                CountryName = "New GeoLocation1",
                CountryCode = "DGK Road GeoLocation1",
                Currency = "0647839920",
                CurrencyCode = "CurrencyCode1"
            };

            int userId = 1;
            var newuser = GeoLocationService.CreateGeoLocation(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}