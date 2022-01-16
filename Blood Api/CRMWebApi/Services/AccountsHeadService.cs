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

    public class AccountsHeadService : IAccountsHeadService
    {
        public AccountsHeadViewModel CreateAccountsHead(AccountsHeadBindingModel model, int userId)
        {
            AccountsHead entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            AccountsHeadViewModel model2 = new AccountsHeadViewModel();
            AccountsHeadRepository repository = new AccountsHeadRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteAccountsHead(int AccountsHeadId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountsHeadRepository repository = new AccountsHeadRepository(context);
            AccountsHead entity = repository.FindOne(AccountsHeadId).FirstOrDefault<AccountsHead>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AccountsHeadId. AccountsHead Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public AccountsHeadViewModel GetAccountsHeadByAccountsHeadId(int AccountsHeadId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountsHeadRepository repository = new AccountsHeadRepository(context);
            if (repository.FindOne(AccountsHeadId).FirstOrDefault<AccountsHead>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AccountsHeadId. AccountsHead Not Found.");
            }
            var result = repository.FindOneMapped(AccountsHeadId);
            
            return result;
        }

        public NashPagedList<AccountsHeadViewModel> GetAccountsHead(int rows, int pageNumber , string SearchString ="")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountsHeadRepository repository = new AccountsHeadRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber).ToViewModel();
            
            return result;
        }
        
        public AccountsHeadViewModel UpdateAccountsHead(AccountsHeadBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountsHeadRepository repository = new AccountsHeadRepository(context);
            int? AccountsHeadId = model.AccountsHeadId;
            AccountsHead original = repository.FindOne(AccountsHeadId.HasValue ? AccountsHeadId.GetValueOrDefault() : 0).FirstOrDefault<AccountsHead>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AccountsHeadId. AccountsHead Not Found.");
            }
            AccountsHead entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetAccountsHeadByAccountsHeadId(entity.Id);
        }


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

