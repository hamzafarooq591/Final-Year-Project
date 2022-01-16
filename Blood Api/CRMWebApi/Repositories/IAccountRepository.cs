namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IAccountRepository : IRepository<Account>
    {
        IPagedList<Account> Filter(int rows, int pageNumber, int? BranchId = null);
        IQueryable<Account> FindOne(int AccountId);
        AccountViewModel FindOneMapped(int AccountId);
        IPagedList<Account> FilterforParentAccount(int rows, int pageNumber);
    }
}

