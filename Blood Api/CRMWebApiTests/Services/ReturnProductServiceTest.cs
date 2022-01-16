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
    public class ReturnProductServiceTests
    {



        [TestMethod()]
        public void CreateReturnProductTest()
        {
            ReturnProductService ReturnProductService = new ReturnProductService();
            ProductService productService = new ProductService();
            CustomerService customerService = new CustomerService();
            ReturnProductBindingModel model = new ReturnProductBindingModel
            {
                CustomerId = customerService.GetCustomer(1,1).Data[0].CustomerId.Value,
                ProductId = productService.GetProduct(1,1,"").Data[0].ProductId,
                ReturnProductDate = DateTime.Now.ToString(),
                ReturnQuantity = 4
            };

            int userId = 1;
            var newuser = ReturnProductService.CreateReturnProduct(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }

        [TestMethod()]
        public void GetReturnProductTest()
        {
            ReturnProductService ReturnProductService = new ReturnProductService();
            var ReturnProductList = ReturnProductService.GetReturnProduct(10, 1);
            ReturnProductList.Data.ToList();
        }
    }
}