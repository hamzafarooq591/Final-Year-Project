namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ICurrencyRepository : IRepository<Currency>
    {
        IPagedList<Currency> Filter(int rows, int pageNumber);
        IQueryable<Currency> FindOne(int CurrencyId);
        CurrencyViewModel FindOneMapped(int CurrencyId);
    }
}

