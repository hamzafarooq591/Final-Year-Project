namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IBankRepository : IRepository<Bank>
    {
        IPagedList<Bank> Filter(int rows, int pageNumber, string SearchString = "");
        IQueryable<Bank> FindOne(int BankId);
        BankViewModel FindOneMapped(int BankId);
    }
}

