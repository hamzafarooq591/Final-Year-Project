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
    public class InvoiceMasterServiceTests
    {



        [TestMethod()]
        public void CreateInvoiceMasterTest()
        {
            InvoiceMasterService InvoiceMasterService = new InvoiceMasterService();
            ManufacturerService manufacturerService = new ManufacturerService();
            InvoiceMasterBindingModel model = new InvoiceMasterBindingModel
            {
                BillToId = 1,
                InvoiceDate = DateTime.Now,
                InvoiceNo = "New InvoiceMaster Image",
                GrandTotal = 29500,
                PayOrderNumber = "",
                SaleTax = 3000,
                TotalAmount = 32500,
                BillToTypeId = 1
            };

            int userId = 1;
            var newuser = InvoiceMasterService.CreateInvoiceMaster(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
    }
}