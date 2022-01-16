namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IMoneyChangerRepository : IRepository<MoneyChanger>
    {
        IPagedList<MoneyChanger> Filter(int rows, int pageNumber);
        IQueryable<MoneyChanger> FindOne(int MoneyChangerId);
        MoneyChangerViewModel FindOneMapped(int MoneyChangerId);
    }
}

