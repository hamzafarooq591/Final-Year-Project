namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class GeoLocationRepository : Repository<GeoLocation>, IGeoLocationRepository, IRepository<GeoLocation>
    {
        public GeoLocationRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<GeoLocation> Filter(int rows, int pageNumber)
        {
           
            return NashContext.GeoLocations
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<GeoLocation>(pageNumber, rows);
        }

        public IQueryable<GeoLocation> FindOne(int GeoLocationId)
        {

            return NashContext.GeoLocations
                .Where(x => x.IsDeleted == false && x.Id == GeoLocationId);
        }

        public GeoLocationViewModel FindOneMapped(int GeoLocationId) => 
            this.FindOne(GeoLocationId).FirstOrDefault<GeoLocation>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

