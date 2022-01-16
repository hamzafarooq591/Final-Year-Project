namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IInventoryStockRepository : IRepository<InventoryStock>
    {
        IPagedList<InventoryStock> Filter(int rows, int pageNumber);
        IQueryable<InventoryStock> FindOne(int InventoryStockId);
        InventoryStockViewModel FindOneMapped(int InventoryStockId);
    }
}

