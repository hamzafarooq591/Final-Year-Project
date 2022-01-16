namespace NashWebApi.Services
{
    using NashWebApi;
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Exceptions.NashHandledException;
    using NashWebApi.Extensions;
    using NashWebApi.Mappers;
    using NashWebApi.Repositories;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constant;

    public class TransactionService : ITransactionService
    {
        public TransactionViewModel CreateTransaction(TransactionBindingModel model, int userId)
        {
            Transaction entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            TransactionViewModel model2 = new TransactionViewModel();
            TransactionRepository repository = new TransactionRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteTransaction(int TransactionId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            TransactionRepository repository = new TransactionRepository(context);
            Transaction entity = repository.FindOne(TransactionId).FirstOrDefault<Transaction>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid TransactionId. Transaction Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public TransactionViewModel GetTransactionByTransactionId(int TransactionId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            TransactionRepository repository = new TransactionRepository(context);
            if (repository.FindOne(TransactionId).FirstOrDefault<Transaction>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid TransactionId. Transaction Not Found.");
            }
            return repository.FindOneMapped(TransactionId);
        }

        public NashPagedList<TransactionInquiryViewModel> GetTransaction(int rows, int pageNumber,
            int? AccountId = null, DateTime? FromDate = null, DateTime? ToDate = null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            List<TransactionInquiryViewModel> transactionViewModelList = new List<TransactionInquiryViewModel>();
            TransactionRepository repository = new TransactionRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, AccountId, FromDate, ToDate).ToTransactionInquiryViewModel();
        }
        //Create Transaction List
        public bool CreateTransactionList(List<TransactionBindingModel> models, int userId)
        {
            try
            {
                foreach (var model in models)
                {

                    Transaction entity = model.ToEntity(userId, null);

                    NashWebApi.NashContext context = new NashWebApi.NashContext();

                    TransactionViewModel model2 = new TransactionViewModel();
                    TransactionRepository repository = new TransactionRepository(context);
                    using (UnitOfWork work = new UnitOfWork(context))
                    {
                        entity = repository.Add(entity);
                        work.Complete();
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public TransactionViewModel UpdateTransaction(TransactionBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            TransactionRepository repository = new TransactionRepository(context);
            int? TransactionId = model.TransactionId;
            Transaction original = repository.FindOne(TransactionId.HasValue ? TransactionId.GetValueOrDefault() : 0).FirstOrDefault<Transaction>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid TransactionId. Transaction Not Found.");
            }
            Transaction entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetTransactionByTransactionId(entity.Id);
        }

        //Account Ledger
        public NashPagedList<LedgerViewModel> GetTransactionByAccountId(int rows, int pageNumber, int accountId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            List<LedgerViewModel> ledgerViewModelList = new List<LedgerViewModel>();

            TransactionRepository repository = new TransactionRepository(context);
            return repository.FilterByAccountId(rows, pageNumber, accountId).ToLedgerViewModel();

        }

        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

