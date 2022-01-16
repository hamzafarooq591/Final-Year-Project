namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IVendorPODetailRepository : IRepository<VendorPODetail>
    {
        IPagedList<VendorPODetail> Filter(int rows, int pageNumber);
        IQueryable<VendorPODetail> FindOne(int VendorPODetailId);
        VendorPODetailViewModel FindOneMapped(int VendorPODetailId);
    }
}

