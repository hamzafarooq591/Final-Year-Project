namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IVendorRepository : IRepository<Vendor>
    {
        IPagedList<Vendor> Filter(int rows, int pageNumber);
        IQueryable<Vendor> FindOne(int VendorId);
        VendorViewModel FindOneMapped(int VendorId);
    }
}

