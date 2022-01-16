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
    public class CourierCompanyServiceTests
    {



        [TestMethod()]
        public void CreateCourierCompanyTest()
        {
            CourierCompanyService CourierCompanyService = new CourierCompanyService();
            CourierCompanyBindingModel model = new CourierCompanyBindingModel
            {
                CourierCompanyName = "New CourierCompany1",
                CourierCompanyNumber = "+9201223094032"
            };

            int userId = 1;
            var newuser = CourierCompanyService.CreateCourierCompany(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}