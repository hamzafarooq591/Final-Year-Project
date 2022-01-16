namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ITransactionService
    {
        TransactionViewModel CreateTransaction(TransactionBindingModel model, int userId);
        bool DeleteTransaction(int TransactionId);
        TransactionViewModel GetTransactionByTransactionId(int TransactionId);
        NashPagedList<TransactionInquiryViewModel> GetTransaction(int rows, int pageNumber,
                    int? AccountId = null, DateTime? FromDate = null, DateTime? ToDate = null);
        TransactionViewModel UpdateTransaction(TransactionBindingModel model, int userId);
        NashPagedList<LedgerViewModel> GetTransactionByAccountId(int rows, int pageNumber, int accountId);
        //NashPagedList<TrialBalanceViewModel> GetTrialBalance(int rows, int pageNumber);
        bool CreateTransactionList(List<TransactionBindingModel> models, int userId);
    }
}

