namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IOrderProductWarrantyService
    {
        OrderProductWarrantyViewModel CreateOrderProductWarranty(OrderProductWarrantyBindingModel model, int userId);
        bool DeleteOrderProductWarranty(int OrderProductWarrantyId);
        OrderProductWarrantyViewModel GetOrderProductWarrantyByOrderProductWarrantyId(int OrderProductWarrantyId);
        NashPagedList<OrderProductWarrantyViewModel> GetOrderProductWarranty(int rows, int pageNumber, string SearchString = "");
        OrderProductWarrantyViewModel UpdateOrderProductWarranty(OrderProductWarrantyBindingModel model, int userId);
    }
}

