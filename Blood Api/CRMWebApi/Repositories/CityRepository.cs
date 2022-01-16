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

    public class CityRepository : Repository<City>, ICityRepository, IRepository<City>
    {
        public CityRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<City> Filter(int rows, int pageNumber, int? GeoLocationId)
        {

            var result = NashContext.Cities
                .Include(x => x.GeoLocation)
                .Where(x => x.IsDeleted == false);

            if (GeoLocationId.HasValue)
            {
                result = result.Where(x => x.GeoLocationId == GeoLocationId);
            }

            return result.OrderByDescending(o => o.Id)
                .ToPagedList<City>(pageNumber, rows);
        }

        public IQueryable<City> FindOne(int CityId)
        {
            return this.NashContext.Cities
                .Include(x => x.GeoLocation)
                .Where(x => x.IsDeleted == false && x.Id == CityId);
        }

        public CityViewModel FindOneMapped(int CityId) => 
            this.FindOne(CityId).FirstOrDefault<City>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

