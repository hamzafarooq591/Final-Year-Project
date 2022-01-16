namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ITransactionRepository : IRepository<Transaction>
    {
        IQueryable<Transaction> FindOne(int TransactionId);
        TransactionViewModel FindOneMapped(int TransactionId);
        IPagedList<Transaction> Filter(int rows, int pageNumber, int? AccountId = null,
            DateTime? FromDate = null, DateTime? ToDate = null);
    }
}

