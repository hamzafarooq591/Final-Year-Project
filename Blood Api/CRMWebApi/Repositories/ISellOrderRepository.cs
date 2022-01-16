namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ISellOrderRepository : IRepository<SellOrder>
    {
        IPagedList<SellOrder> Filter(int rows, int pageNumber, bool? isCompleted = null);
        IQueryable<SellOrder> FindOne(int SellOrderId);
        SellOrderViewModel FindOneMapped(int SellOrderId);
    }
}

