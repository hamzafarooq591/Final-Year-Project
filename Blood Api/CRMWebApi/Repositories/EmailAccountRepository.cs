namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections.Generic;

    public class EmailAccountRepository : Repository<EmailAccount>, IEmailAccountRepository, IRepository<EmailAccount>
    {
        public EmailAccountRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<EmailAccount> Filter(int rows, int pageNumber)
        {

            return NashContext.EmailAccounts
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<EmailAccount>(pageNumber, rows);
        }

        public IQueryable<EmailAccount> FindOne(int EmailAccountId)
        {

            return NashContext.EmailAccounts
                .Where(x => x.IsDeleted == false && x.Id == EmailAccountId);
        }

        public EmailAccountViewModel FindOneMapped(int EmailAccountId) =>
            this.FindOne(EmailAccountId).FirstOrDefault<EmailAccount>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

