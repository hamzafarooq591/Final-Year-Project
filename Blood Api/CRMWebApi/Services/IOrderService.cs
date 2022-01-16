namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IOrderService
    {
        OrderViewModel CreateOrder(OrderBindingModel model, int userId);
        bool DeleteOrder(int OrderId);
        OrderViewModel GetOrderByOrderId(int OrderId);
        NashPagedList<OrderViewModel> GetOrder(int rows, int pageNumber, string CompanyName = "",
            string BranchName = "", string CustomerName = "", int? OrderStatusId=null, int? OrderId = null, DateTime? FromDate = null, DateTime? ToDate = null);
        OrderViewModel UpdateOrder(OrderBindingModel model, int userId);
    }
}

