namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IInventoryRequestRepository : IRepository<InventoryRequest>
    {
        IPagedList<InventoryRequest> Filter(int rows, int pageNumber);
        IQueryable<InventoryRequest> FindOne(int InventoryRequestId);
        InventoryRequestViewModel FindOneMapped(int InventoryRequestId);
    }
}

