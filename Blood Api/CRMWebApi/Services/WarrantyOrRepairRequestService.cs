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

    public class WarrantyOrRepairRequestService : IWarrantyOrRepairRequestService
    {
        public WarrantyOrRepairRequestViewModel CreateWarrantyOrRepairRequest(WarrantyOrRepairRequestBindingModel model, int userId)
        {
            WarrantyOrRepairRequest entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            WarrantyOrRepairRequestViewModel model2 = new WarrantyOrRepairRequestViewModel();
            WarrantyOrRepairRequestRepository repository = new WarrantyOrRepairRequestRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteWarrantyOrRepairRequest(int WarrantyOrRepairRequestId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyOrRepairRequestRepository repository = new WarrantyOrRepairRequestRepository(context);
            WarrantyOrRepairRequest entity = repository.FindOne(WarrantyOrRepairRequestId).FirstOrDefault<WarrantyOrRepairRequest>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyOrRepairRequestId. WarrantyOrRepairRequest Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public WarrantyOrRepairRequestViewModel GetWarrantyOrRepairRequestByWarrantyOrRepairRequestId(int WarrantyOrRepairRequestId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyOrRepairRequestRepository repository = new WarrantyOrRepairRequestRepository(context);
            if (repository.FindOne(WarrantyOrRepairRequestId).FirstOrDefault<WarrantyOrRepairRequest>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyOrRepairRequestId. WarrantyOrRepairRequest Not Found.");
            }
            return repository.FindOneMapped(WarrantyOrRepairRequestId);
        }

        public NashPagedList<WarrantyOrRepairRequestViewModel> GetWarrantyOrRepairRequest(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyOrRepairRequestRepository repository = new WarrantyOrRepairRequestRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public WarrantyOrRepairRequestViewModel UpdateWarrantyOrRepairRequest(WarrantyOrRepairRequestBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyOrRepairRequestRepository repository = new WarrantyOrRepairRequestRepository(context);
            int? WarrantyOrRepairRequestId = model.WarrantyOrRepairRequestId;
            WarrantyOrRepairRequest original = repository.FindOne(WarrantyOrRepairRequestId.HasValue ? WarrantyOrRepairRequestId.GetValueOrDefault() : 0).FirstOrDefault<WarrantyOrRepairRequest>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyOrRepairRequestId. WarrantyOrRepairRequest Not Found.");
            }
            WarrantyOrRepairRequest entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetWarrantyOrRepairRequestByWarrantyOrRepairRequestId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

