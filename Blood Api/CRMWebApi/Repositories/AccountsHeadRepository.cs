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
    
    public class AccountsHeadRepository : Repository<AccountsHead>, IAccountsHeadRepository, IRepository<AccountsHead>
    {
        public AccountsHeadRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<AccountsHead> Filter(int rows, int pageNumber)
        {
            var result = NashContext.AccountsHeads
                .Include(x => x.Asset)
                .Include(x => x.Liability)
                .Include(x => x.Expenses)
                .Include(x => x.EquityOrCapital)
                .Include(x => x.IncomeOrRevenue)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<AccountsHead>(pageNumber, rows);
        }
         
        public AccountsHeadViewModel FindOneMapped(int AccountsHeadId) =>
            this.FindOne(AccountsHeadId).FirstOrDefault<AccountsHead>().ToViewModel();

        public IQueryable<AccountsHead> FindOne(int AccountsHeadId)
        {
            return NashContext.AccountsHeads
                .Include(x => x.Asset)
                .Include(x => x.Liability)
                .Include(x => x.Expenses)
                .Include(x => x.EquityOrCapital)
                .Include(x => x.IncomeOrRevenue)
                .Where(x => x.Id == AccountsHeadId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

