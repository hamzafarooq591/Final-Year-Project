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

    public class TransactionRepository : Repository<Transaction>, ITransactionRepository, IRepository<Transaction>
    {
        public TransactionRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Transaction> Filter(int rows, int pageNumber, int? AccountId = null,
            DateTime? FromDate = null, DateTime? ToDate = null)
        {
            var result = NashContext.Transactions
                .Include(x => x.Account)
                .Include(x => x.Account.Branch)
                .Include(x => x.Account.Branch.Company)
               .Where(x => x.IsDeleted == false &&
               ((AccountId == null || x.Account.Id == AccountId)
               &&
               (FromDate == null || x.CreatedOn >= FromDate)
               &&
               (ToDate == null || x.CreatedOn <= ToDate)
               ));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Transaction>(pageNumber, rows);
        }

        public IPagedList<Transaction> FilterByAccountId(int rows, int pageNumber, int accountId)
        {
            var result = NashContext.Transactions
                .Include(x => x.Account)
               .Where(x => x.IsDeleted == false && x.AccountId == accountId);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Transaction>(pageNumber, rows);
        }

        public float TotalTransactionAmountByAccountIdAndTransactionType(int accountId, bool transactionType)
        {
            var result = NashContext.Transactions
               .Where(x => x.IsDeleted == false && x.AccountId == accountId && x.TransactionType == transactionType);
            float TotalTransactionAmount = 0;

            foreach (var trans in result)
            {
                TotalTransactionAmount += trans.Amount;
            }


            return TotalTransactionAmount;
        }

        public TransactionViewModel FindOneMapped(int TransactionId) =>
            this.FindOne(TransactionId).FirstOrDefault<Transaction>().ToViewModel();

        public IQueryable<Transaction> FindOne(int TransactionId)
        {
            return NashContext.Transactions
                .Include(x => x.Account)
                .Where(x => x.Id == TransactionId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

