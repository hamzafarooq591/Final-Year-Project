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
    
    public class AccountRepository : Repository<Account>, IAccountRepository, IRepository<Account>
    {
        public AccountRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Account> Filter(int rows, int pageNumber , int? BranchId = null)
        {
            var result = NashContext.Accounts
               .Include(x => x.Branch)
                .Include(x => x.ParentAccount)
               .Where(x =>  x.IsDeleted == false && (BranchId == null ||x.Branch.Id==BranchId));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Account>(pageNumber, rows);
        }
        //ParentAccountId List
        public IPagedList<Account> FilterforParentAccount(int rows, int pageNumber)
        {
            var result = NashContext.Accounts
                .Include(x => x.ParentAccount)
               .Where(x => x.IsDeleted == false &&  x.ParentAccountId == null);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Account>(pageNumber, rows);
        }
        //End ParentAccountId List

        public AccountViewModel FindOneMapped(int AccountId) =>
            this.FindOne(AccountId).FirstOrDefault<Account>().ToViewModel();

        public IQueryable<Account> FindOne(int AccountId)
        {
            return NashContext.Accounts
                .Include(x => x.Branch)
                .Include(x => x.ParentAccount)
                .Where(x => x.Id == AccountId && x.IsDeleted == false);
        }

        public IQueryable<Account> GetChildAccountsByAccountHeadId(int AccountHeadId)
        {
            return NashContext.Accounts
                .Where(x => x.AccountHeadId == AccountHeadId && x.IsDeleted == false);

        }

        public IQueryable<Account> GetChildAccounts(int parentAccountId)
        {
            return NashContext.Accounts
                .Where(x => x.ParentAccountId == parentAccountId && x.IsDeleted == false);
               
        }
        //Profit & Loss
        public ProfitLossReportViewModel GetProfitAndLoss()
        {
             return GetProfitAndLoss();
        }
        //TrailBalance
        public IPagedList<Account> GetTrailBalance(int rows, int pageNumber, string SearchString = "")
        {
            var result = NashContext.Accounts
               .Where(x => x.IsDeleted == false && (SearchString == "" || x.AccountName.Contains(SearchString)));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Account>(pageNumber, rows);
        }


        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

