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
    public class OrderServiceTests
    {



        [TestMethod()]
        public void CreateOrderTest()
        {
            OrderService OrderService = new OrderService();
            ProductService productService = new ProductService();
            CustomerService customerService = new CustomerService();
            NashUserService nashUserService = new NashUserService();
            OrderBindingModel model = new OrderBindingModel
            {
                OrderPlacementDate = DateTime.Now,
                OrderQuantity = 3,
                ProductId = productService.GetProduct(1, 1, "").Data[0].ProductId,
                CustomerId = 1,
                NashUserId = nashUserService.GetNashUsers(1, 1, 1, "").Data[0].NashUserId,
                OrderStatusId = 1,
                InvoiceId = 2
            };

            int userId = 1;
            var newuser = OrderService.CreateOrder(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }

        //[TestMethod()]
        //public void GetOrderTest()
        //{
        //    OrderService orderService = new OrderService();
        //    var OrderList = orderService.GetOrder(10,1);
        //    OrderList.Data.ToList();
        //}
        [TestMethod()]
        public void GetOrderTest()
        {
            OrderService orderService = new OrderService();
            var OrderList = orderService.GetOrder(10, 1,BranchName:"Nursury",OrderId:11);
            OrderList.Data.ToList();
        }
        [TestMethod()]
        public void GetOrderByOrderIdTest()
        {
            OrderService orderService = new OrderService();
            var OrderList = orderService.GetOrderByOrderId(6);
        }
        [TestMethod()]
        public void UpdateOrderTest()
        {
            OrderService orderService = new OrderService();
            OrderBindingModel orderBinding = new OrderBindingModel()
            {
                CustomerId = 1,
                InvoiceId = 2,
                NashUserId = 61,
                OrderPlacementDate = DateTime.Now,
                OrderQuantity = 99,
                OrderStatusId = 1,
                ProductId = 1
            };
            var OrderList = orderService.UpdateOrder(orderBinding , orderService.GetOrder(1,1).Data[0].OrderId);
        }
    }
}