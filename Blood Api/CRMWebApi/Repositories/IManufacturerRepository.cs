﻿namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        //IPagedList<City> Filter(int rows, int pageNumber, int? CityTypeId);
        //IQueryable<City> FindOne(int CityId);
        //CityViewModel FindOneMapped(int CityId);
    }
}

