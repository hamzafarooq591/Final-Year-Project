namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IWarrantyOrRepairRequestRepository : IRepository<WarrantyOrRepairRequest>
    {
        IPagedList<WarrantyOrRepairRequest> Filter(int rows, int pageNumber);
        IQueryable<WarrantyOrRepairRequest> FindOne(int CreateWarrantyId);
        WarrantyOrRepairRequestViewModel FindOneMapped(int CreateWarrantyId);
    }
}

