namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        IPagedList<Warehouse> Filter(int rows, int pageNumber);
        IQueryable<Warehouse> FindOne(int WarehouseId);
        WarehouseViewModel FindOneMapped(int WarehouseId);
    }
}

