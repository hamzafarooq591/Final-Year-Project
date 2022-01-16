namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IWarrantyRequestStatusRepository : IRepository<WarrantyRequestStatus>
    {
        IPagedList<WarrantyRequestStatus> Filter(int rows, int pageNumber);
        IQueryable<WarrantyRequestStatus> FindOne(int WarrantyRequestStatusId);
        WarrantyRequestStatusViewModel FindOneMapped(int WarrantyRequestStatuId);
    }
}

