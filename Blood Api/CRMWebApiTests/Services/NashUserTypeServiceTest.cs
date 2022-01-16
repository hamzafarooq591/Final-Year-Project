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
    public class NashUserTypeServiceTests
    {



        [TestMethod()]
        public void CreateNashUserTypeTest()
        {
            NashUserService nashUserTypeService = new NashUserService();
            AccountService accountService = new AccountService();
            NashUserTypeBindingModel model = new NashUserTypeBindingModel
            {
                Name = "Branch Manager",
                Description = "Manager at Branches",
            };

            int userId = 1;
            var newuser = nashUserTypeService.CreateNashUserType(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}