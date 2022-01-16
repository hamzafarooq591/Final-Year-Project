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

    public class CurrencyService : ICurrencyService
    {
        public CurrencyViewModel CreateCurrency(CurrencyBindingModel model, int userId)
        {
            Currency entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            CurrencyViewModel model2 = new CurrencyViewModel();
            CurrencyRepository repository = new CurrencyRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteCurrency(int CurrencyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CurrencyRepository repository = new CurrencyRepository(context);
            Currency entity = repository.FindOne(CurrencyId).FirstOrDefault<Currency>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CurrencyId. Currency Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public CurrencyViewModel GetCurrencyByCurrencyId(int CurrencyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CurrencyRepository repository = new CurrencyRepository(context);
            if (repository.FindOne(CurrencyId).FirstOrDefault<Currency>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CurrencyId. Currency Not Found.");
            }
            return repository.FindOneMapped(CurrencyId);
        }

        public NashPagedList<CurrencyViewModel> GetCurrency(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CurrencyRepository repository = new CurrencyRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public CurrencyViewModel UpdateCurrency(CurrencyBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CurrencyRepository repository = new CurrencyRepository(context);
            int? CurrencyId = model.CurrencyId;
            Currency original = repository.FindOne(CurrencyId.HasValue ? CurrencyId.GetValueOrDefault() : 0).FirstOrDefault<Currency>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CurrencyId. Currency Not Found.");
            }
            Currency entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetCurrencyByCurrencyId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

