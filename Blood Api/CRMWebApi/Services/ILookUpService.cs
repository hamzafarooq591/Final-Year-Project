namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;

    public interface ILookUpService
    {
        CityViewModel CreateCity(CityBindingModel model, int userId);
       
        GeoLocationViewModel CreateGeoLocation(GeoLocationBindingModel model, int userId);
        bool DeleteCity(int LookUpId);
       
        bool DeleteGeoLocation(int LookUpId);
        NashPagedList<CityViewModel> GetCities(int rows, int pageNumber, int? GeoLocationId);
        CityViewModel GetCityByCityId(int CityId);
        
        GeoLocationViewModel GetGeoLocationByGeoLocationId(int GeoLocationId);
        NashPagedList<GeoLocationViewModel> GetGeoLocations(int rows, int pageNumber);
        CityViewModel UpdateCity(CityBindingModel model, int userId);
       
        GeoLocationViewModel UpdateGeoLocation(GeoLocationBindingModel model, int userId);
    }
}

