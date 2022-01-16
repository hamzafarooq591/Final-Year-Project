namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IWPQuantityRepository : IRepository<WPQuantity>
    {
        IPagedList<WPQuantity> Filter(int rows, int pageNumber);
        IQueryable<WPQuantity> FindOne(int WPQuantityId);
        WPQuantityViewModel FindOneMapped(int WPQuantityId);
    }
}

