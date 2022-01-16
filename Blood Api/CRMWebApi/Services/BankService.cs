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

    public class BankService : IBankService
    {
        public BankViewModel CreateBank(BankBindingModel model, int userId)
        {
            Bank entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            BankViewModel model2 = new BankViewModel();
            BankRepository repository = new BankRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteBank(int BankId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BankRepository repository = new BankRepository(context);
            Bank entity = repository.FindOne(BankId).FirstOrDefault<Bank>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BankId. Bank Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public BankViewModel GetBankByBankId(int BankId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BankRepository repository = new BankRepository(context);
            if (repository.FindOne(BankId).FirstOrDefault<Bank>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BankId. Bank Not Found.");
            }
            return repository.FindOneMapped(BankId);
        }

        public NashPagedList<BankViewModel> GetBank(int rows, int pageNumber , string SearchString ="")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BankRepository repository = new BankRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }
        
        public BankViewModel UpdateBank(BankBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BankRepository repository = new BankRepository(context);
            int? BankId = model.BankId;
            Bank original = repository.FindOne(BankId.HasValue ? BankId.GetValueOrDefault() : 0).FirstOrDefault<Bank>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BankId. Bank Not Found.");
            }
            Bank entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetBankByBankId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

