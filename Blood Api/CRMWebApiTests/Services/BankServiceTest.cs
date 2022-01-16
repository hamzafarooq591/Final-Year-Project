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
    public class BankServiceTests
    {



        [TestMethod()]
        public void CreateBankTest()
        {
            BankService BankService = new BankService();
            BankBindingModel model = new BankBindingModel
            {
                BankName = "New Bank1",
                BankAddress = "DGK Road Bank1",
                BankPhoneNo = "0647839920"
            };

            int userId = 1;
            var newuser = BankService.CreateBank(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}