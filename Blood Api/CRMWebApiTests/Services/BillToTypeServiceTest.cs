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
    public class BillToTypeServiceTests
    {



        [TestMethod()]
        public void CreateBillToTypeTest()
        {
            BillToTypeService BillToTypeService = new BillToTypeService();
            BillToTypeBindingModel model = new BillToTypeBindingModel
            {
                Title = "New BillToType1",
                Description = "DGK BillToType1"
            };

            int userId = 1;
            var newuser = BillToTypeService.CreateBillToType(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}