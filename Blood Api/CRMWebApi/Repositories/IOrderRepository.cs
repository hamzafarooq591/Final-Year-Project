namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IOrderRepository : IRepository<Order>
    {
        IPagedList<Order> Filter(int rows, int pageNumber, string CompanyName,
            string BranchName, string CustomerName,int? OrderStatusId, int? OrderId, DateTime? FromDate, DateTime? ToDate);
        IQueryable<Order> FindOne(int OrderId);
        OrderViewModel FindOneMapped(int OrderId);
    }
}

