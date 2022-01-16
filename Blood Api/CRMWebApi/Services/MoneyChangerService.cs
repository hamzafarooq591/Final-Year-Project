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

    public class MoneyChangerService : IMoneyChangerService
    {
        public MoneyChangerViewModel CreateMoneyChanger(MoneyChangerBindingModel model, int userId)
        {
            MoneyChanger entity = model.ToEntity(userId, null);
            AccountsHeadRepository accountsHeadRepository = new AccountsHeadRepository(NashContext);
            /////////////////////////////////On creation of money changer new Account for money changer is created/////////////////////////////////
            Account account = new Account
            {
                AccountName = model.MCName + "Account",
                AccountDescription = "Money Changer Account" + model.MCName,
                AccountHeadId = accountsHeadRepository.GetAll().FirstOrDefault<AccountsHead>().AssetId,
            };

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            MoneyChangerViewModel model2 = new MoneyChangerViewModel();
            MoneyChangerRepository repository = new MoneyChangerRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteMoneyChanger(int MoneyChangerId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            MoneyChangerRepository repository = new MoneyChangerRepository(context);
            MoneyChanger entity = repository.FindOne(MoneyChangerId).FirstOrDefault<MoneyChanger>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid MoneyChangerId. MoneyChanger Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public MoneyChangerViewModel GetMoneyChangerByMoneyChangerId(int MoneyChangerId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            MoneyChangerRepository repository = new MoneyChangerRepository(context);
            if (repository.FindOne(MoneyChangerId).FirstOrDefault<MoneyChanger>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid MoneyChangerId. MoneyChanger Not Found.");
            }
            return repository.FindOneMapped(MoneyChangerId);
        }

        public NashPagedList<MoneyChangerViewModel> GetMoneyChanger(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            MoneyChangerRepository repository = new MoneyChangerRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public MoneyChangerViewModel UpdateMoneyChanger(MoneyChangerBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            MoneyChangerRepository repository = new MoneyChangerRepository(context);
            int? MoneyChangerId = model.MoneyChangerId;
            MoneyChanger original = repository.FindOne(MoneyChangerId.HasValue ? MoneyChangerId.GetValueOrDefault() : 0).FirstOrDefault<MoneyChanger>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid MoneyChangerId. MoneyChanger Not Found.");
            }
            MoneyChanger entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetMoneyChangerByMoneyChangerId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

