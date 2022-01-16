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
    public class ClearingAgentServiceTests
    {



        [TestMethod()]
        public void CreateClearingAgentTest()
        {
            ClearingAgentService ClearingAgentService = new ClearingAgentService();
            CompanyService companyService = new CompanyService();
            ClearingAgentBindingModel model = new ClearingAgentBindingModel
            {
                CAName = "New ClearingAgent1",
                Address = "DGK ClearingAgent1",
                City = "New ClearingAgent Image",
                CompanyId = companyService.GetCompany(1, 1, "").Data[0].CompanyId,
                Country = "Country1",
                Email = "CA1 Email",
                FaxNo = "CA1 FaxNo",
                IsActive = true,
                MobileNo = "CA1 Mobile No"
            };

            int userId = 1;
            var newuser = ClearingAgentService.CreateClearingAgent(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}