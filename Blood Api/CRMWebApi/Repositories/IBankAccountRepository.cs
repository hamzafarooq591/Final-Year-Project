namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IBankAccountRepository : IRepository<BankAccount>
    {
        IPagedList<BankAccount> Filter(int rows, int pageNumber);
        IQueryable<BankAccount> FindOne(int BankAccountId);
        BankAccountViewModel FindOneMapped(int BankAccountId);
    }
}

