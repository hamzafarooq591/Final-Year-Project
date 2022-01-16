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
    
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository, IRepository<BankAccount>
    {
        public BankAccountRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<BankAccount> Filter(int rows, int pageNumber)
        {
            var result = NashContext.BankAccounts
                .Include(x => x.Company)
                .Include(x => x.Bank)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<BankAccount>(pageNumber, rows);
        }
         
        public BankAccountViewModel FindOneMapped(int BankAccountId) =>
            this.FindOne(BankAccountId).FirstOrDefault<BankAccount>().ToViewModel();

        public IQueryable<BankAccount> FindOne(int BankAccountId)
        {
            return NashContext.BankAccounts
                .Include(x => x.Company)
                .Include(x => x.Bank)
                .Where(x => x.Id == BankAccountId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

