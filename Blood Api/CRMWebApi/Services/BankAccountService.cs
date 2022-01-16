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

    public class BankAccountService : IBankAccountService
    {
        public BankAccountViewModel CreateBankAccount(BankAccountBindingModel model, int userId)
        {
            BankAccount entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            BankAccountViewModel model2 = new BankAccountViewModel();
            BankAccountRepository repository = new BankAccountRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteBankAccount(int BankAccountId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BankAccountRepository repository = new BankAccountRepository(context);
            BankAccount entity = repository.FindOne(BankAccountId).FirstOrDefault<BankAccount>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BankAccountId. BankAccount Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public BankAccountViewModel GetBankAccountByBankAccountId(int BankAccountId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BankAccountRepository repository = new BankAccountRepository(context);
            if (repository.FindOne(BankAccountId).FirstOrDefault<BankAccount>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BankAccountId. BankAccount Not Found.");
            }
            return repository.FindOneMapped(BankAccountId);
        }

        public NashPagedList<BankAccountViewModel> GetBankAccount(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BankAccountRepository repository = new BankAccountRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public BankAccountViewModel UpdateBankAccount(BankAccountBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BankAccountRepository repository = new BankAccountRepository(context);
            int? BankAccountId = model.BankAccountId;
            BankAccount original = repository.FindOne(BankAccountId.HasValue ? BankAccountId.GetValueOrDefault() : 0).FirstOrDefault<BankAccount>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BankAccountId. BankAccount Not Found.");
            }
            BankAccount entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetBankAccountByBankAccountId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

