namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IEmailAccountRepository : IRepository<EmailAccount>
    {
        IPagedList<EmailAccount> Filter(int rows, int pageNumber);
        IQueryable<EmailAccount> FindOne(int EmailAccountId);
        EmailAccountViewModel FindOneMapped(int EmailAccountId);
    }
}

