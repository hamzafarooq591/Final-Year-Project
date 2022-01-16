namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IWarrantyRepository : IRepository<Warranty>
    {
        IPagedList<Warranty> Filter(int rows, int pageNumber);
        IQueryable<Warranty> FindOne(int WarrantyId);
        WarrantyViewModel FindOneMapped(int WarrantyId);
    }
}

