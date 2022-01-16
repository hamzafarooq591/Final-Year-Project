namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IGeoLocationRepository : IRepository<GeoLocation>
    {
        IPagedList<GeoLocation> Filter(int rows, int pageNumber);
        IQueryable<GeoLocation> FindOne(int GeoLocationId);
        GeoLocationViewModel FindOneMapped(int GeoLocationId);
    }
}

