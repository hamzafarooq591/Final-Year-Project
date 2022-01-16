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

    public class InventoryRequestService : IInventoryRequestService
    {
        public InventoryRequestViewModel CreateInventoryRequest(InventoryRequestBindingModel model, int userId)
        {
            InventoryRequest entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            InventoryRequestViewModel model2 = new InventoryRequestViewModel();
            InventoryRequestRepository repository = new InventoryRequestRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteInventoryRequest(int InventoryRequestId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InventoryRequestRepository repository = new InventoryRequestRepository(context);
            InventoryRequest entity = repository.FindOne(InventoryRequestId).FirstOrDefault<InventoryRequest>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InventoryRequestId. InventoryRequest Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public InventoryRequestViewModel GetInventoryRequestByInventoryRequestId(int InventoryRequestId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InventoryRequestRepository repository = new InventoryRequestRepository(context);
            if (repository.FindOne(InventoryRequestId).FirstOrDefault<InventoryRequest>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InventoryRequestId. InventoryRequest Not Found.");
            }
            return repository.FindOneMapped(InventoryRequestId);
        }

        public NashPagedList<InventoryRequestViewModel> GetInventoryRequest(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InventoryRequestRepository repository = new InventoryRequestRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public InventoryRequestViewModel UpdateInventoryRequest(InventoryRequestBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InventoryRequestRepository repository = new InventoryRequestRepository(context);
            int? InventoryRequestId = model.InventoryRequestId;
            InventoryRequest original = repository.FindOne(InventoryRequestId.HasValue ? InventoryRequestId.GetValueOrDefault() : 0).FirstOrDefault<InventoryRequest>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InventoryRequestId. InventoryRequest Not Found.");
            }
            InventoryRequest entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetInventoryRequestByInventoryRequestId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

