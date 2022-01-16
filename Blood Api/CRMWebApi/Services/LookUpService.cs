namespace NashWebApi.Services
{
    using NashWebApi;
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Exceptions.NashHandledException;
    using NashWebApi.Extensions;
    using NashWebApi.Mappers;
    using NashWebApi.Repositories;
    using NashWebApi.ViewModels;
    using System;
    using System.Linq;

    public class LookUpService : ILookUpService
    {
        public CityViewModel CreateCity(CityBindingModel model, int userId)
        {
            City entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CityViewModel model2 = new CityViewModel();
            CityRepository repository = new CityRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

       

        public GeoLocationViewModel CreateGeoLocation(GeoLocationBindingModel model, int userId)
        {
            GeoLocation entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            GeoLocationViewModel model2 = new GeoLocationViewModel();
            GeoLocationRepository repository = new GeoLocationRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteCity(int CityId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CityRepository repository = new CityRepository(context);
            City entity = repository.FindOne(CityId).FirstOrDefault<City>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CityId. City Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        

        public bool DeleteGeoLocation(int GeoLocationId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            GeoLocationRepository repository = new GeoLocationRepository(context);
            GeoLocation entity = repository.FindOne(GeoLocationId).FirstOrDefault<GeoLocation>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid GeoLocationId. GeoLocation Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public NashPagedList<CityViewModel> GetCities(int rows, int pageNumber, int? GeoLocationId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CityRepository repository = new CityRepository(context);
            return repository.Filter(rows, pageNumber, GeoLocationId).ToViewModel();
        }

        public CityViewModel GetCityByCityId(int CityId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CityRepository repository = new CityRepository(context);
            if (repository.FindOne(CityId).FirstOrDefault<City>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CityId. City Not Found.");
            }
            return repository.FindOneMapped(CityId);
        }

       

        

        public GeoLocationViewModel GetGeoLocationByGeoLocationId(int GeoLocationId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            GeoLocationRepository repository = new GeoLocationRepository(context);
            if (repository.FindOne(GeoLocationId).FirstOrDefault<GeoLocation>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid GeoLocationId. GeoLocation Not Found.");
            }
            return repository.FindOneMapped(GeoLocationId);
        }

        public NashPagedList<GeoLocationViewModel> GetGeoLocations(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            GeoLocationRepository repository = new GeoLocationRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }

        public CityViewModel UpdateCity(CityBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CityRepository repository = new CityRepository(context);
            int? cityId = model.CityId;
            City original = repository.FindOne(cityId.HasValue ? cityId.GetValueOrDefault() : 0).FirstOrDefault<City>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CityId. City Not Found.");
            }
            City entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetCityByCityId(entity.Id);
        }

      

        public GeoLocationViewModel UpdateGeoLocation(GeoLocationBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            GeoLocationRepository repository = new GeoLocationRepository(context);
            int? geoLocationId = model.GeoLocationId;
            GeoLocation original = repository.FindOne(geoLocationId.HasValue ? geoLocationId.GetValueOrDefault() : 0).FirstOrDefault<GeoLocation>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid GeoLocationId. GeoLocation Not Found.");
            }
            GeoLocation entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetGeoLocationByGeoLocationId(entity.Id);
        }

        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

