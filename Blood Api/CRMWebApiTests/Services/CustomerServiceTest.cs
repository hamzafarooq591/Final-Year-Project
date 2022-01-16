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
    public class CustomerServiceTests
    {



        [TestMethod()]
        public void CreateCustomerTest()
        {
            CustomerService CustomerService = new CustomerService();
            AccountService accountService = new AccountService();
            CustomerBindingModel model = new CustomerBindingModel
            {
                CustomerName = "New Customer1",
                CustomerAddress = "DGK Customer1 Address",
                CustomerCompanyName = "New Customer Company",
                CustomerPhoneNo = "233222",
                // AccountId = accountService.GetAccount(1, 1).Data[0].AccountId
            };

            int userId = 1;
            var newuser = CustomerService.CreateCustomer(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}