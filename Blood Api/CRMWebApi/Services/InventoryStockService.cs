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

    public class InventoryStockService : IInventoryStockService
    {
        public InventoryStockViewModel CreateInventoryStock(InventoryStockBindingModel model, int userId)
        {
            InventoryStock entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            InventoryStockViewModel model2 = new InventoryStockViewModel();
            InventoryStockRepository repository = new InventoryStockRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteInventoryStock(int InventoryStockId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InventoryStockRepository repository = new InventoryStockRepository(context);
            InventoryStock entity = repository.FindOne(InventoryStockId).FirstOrDefault<InventoryStock>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InventoryStockId. InventoryStock Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public InventoryStockViewModel GetInventoryStockByInventoryStockId(int InventoryStockId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InventoryStockRepository repository = new InventoryStockRepository(context);
            if (repository.FindOne(InventoryStockId).FirstOrDefault<InventoryStock>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InventoryStockId. InventoryStock Not Found.");
            }
            return repository.FindOneMapped(InventoryStockId);
        }

        public NashPagedList<InventoryStockViewModel> GetInventoryStock(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InventoryStockRepository repository = new InventoryStockRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public InventoryStockViewModel UpdateInventoryStock(InventoryStockBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InventoryStockRepository repository = new InventoryStockRepository(context);
            int? InventoryStockId = model.InventoryStockId;
            InventoryStock original = repository.FindOne(InventoryStockId.HasValue ? InventoryStockId.GetValueOrDefault() : 0).FirstOrDefault<InventoryStock>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InventoryStockId. InventoryStock Not Found.");
            }
            InventoryStock entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetInventoryStockByInventoryStockId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

