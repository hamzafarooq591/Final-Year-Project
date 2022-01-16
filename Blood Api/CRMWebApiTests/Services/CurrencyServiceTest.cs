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
    public class CurrencyServiceTests
    {



        [TestMethod()]
        public void CreateCurrencyTest()
        {
            CurrencyService CurrencyService = new CurrencyService();
            CurrencyBindingModel model = new CurrencyBindingModel
            {
                CurrencyName = "Pakistani Rupee",
                CurrencySymbol = "Rs.",
                CurrencyTitle = "Rupees"
            };

            int userId = 1;
            var newuser = CurrencyService.CreateCurrency(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}