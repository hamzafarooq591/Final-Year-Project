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

    public class WarehouseService : IWarehouseService
    {
        public WarehouseViewModel CreateWarehouse(WarehouseBindingModel model, int userId)
        {
            Warehouse entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            WarehouseViewModel model2 = new WarehouseViewModel();
            WarehouseRepository repository = new WarehouseRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteWarehouse(int WarehouseId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarehouseRepository repository = new WarehouseRepository(context);
            Warehouse entity = repository.FindOne(WarehouseId).FirstOrDefault<Warehouse>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarehouseId. Warehouse Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public WarehouseViewModel GetWarehouseByWarehouseId(int WarehouseId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarehouseRepository repository = new WarehouseRepository(context);
            if (repository.FindOne(WarehouseId).FirstOrDefault<Warehouse>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarehouseId. Warehouse Not Found.");
            }
            return repository.FindOneMapped(WarehouseId);
        }

        public NashPagedList<WarehouseViewModel> GetWarehouse(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarehouseRepository repository = new WarehouseRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public WarehouseViewModel UpdateWarehouse(WarehouseBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarehouseRepository repository = new WarehouseRepository(context);
            int? WarehouseId = model.WarehouseId;
            Warehouse original = repository.FindOne(WarehouseId.HasValue ? WarehouseId.GetValueOrDefault() : 0).FirstOrDefault<Warehouse>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarehouseId. Warehouse Not Found.");
            }
            Warehouse entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetWarehouseByWarehouseId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

