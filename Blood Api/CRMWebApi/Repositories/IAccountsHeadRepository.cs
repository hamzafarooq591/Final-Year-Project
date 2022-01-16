namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IAccountsHeadRepository : IRepository<AccountsHead>
    {
        IPagedList<AccountsHead> Filter(int rows, int pageNumber);
        IQueryable<AccountsHead> FindOne(int AccountsHeadId);
        AccountsHeadViewModel FindOneMapped(int AccountsHeadId);
    }
}

