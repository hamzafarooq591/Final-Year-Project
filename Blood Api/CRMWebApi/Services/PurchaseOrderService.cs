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

    public class PurchaseOrderService : IPurchaseOrderService
    {
        public PurchaseOrderViewModel CreatePurchaseOrder(PurchaseOrderBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashWebApi.NashContext accContext = new NashWebApi.NashContext();
            
            PurchaseOrder entity = model.ToEntity(userId, null);
            entity.ReminingWeight = entity.QuantityinWeight;

            PurchaseOrderViewModel model2 = new PurchaseOrderViewModel();
            PurchaseOrderRepository repository = new PurchaseOrderRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeletePurchaseOrder(int PurchaseOrderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseOrderRepository repository = new PurchaseOrderRepository(context);
            PurchaseOrder entity = repository.FindOne(PurchaseOrderId).FirstOrDefault<PurchaseOrder>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PurchaseOrderId. PurchaseOrder Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public PurchaseOrderViewModel GetPurchaseOrderByPurchaseOrderId(int PurchaseOrderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseOrderRepository repository = new PurchaseOrderRepository(context);
            if (repository.FindOne(PurchaseOrderId).FirstOrDefault<PurchaseOrder>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PurchaseOrderId. PurchaseOrder Not Found.");
            }
            return repository.FindOneMapped(PurchaseOrderId);
        }

        public NashPagedList<PurchaseOrderViewModel> GetPurchaseOrder(int rows, int pageNumber, bool? isCompleted = null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseOrderRepository repository = new PurchaseOrderRepository(context);
            return repository.Filter(rows, pageNumber,isCompleted).ToViewModel();
        }
        
        public PurchaseOrderViewModel UpdatePurchaseOrder(PurchaseOrderBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseOrderRepository repository = new PurchaseOrderRepository(context);
            int? PurchaseOrderId = model.PurchaseOrderId;
            PurchaseOrder original = repository.FindOne(PurchaseOrderId.HasValue ? PurchaseOrderId.GetValueOrDefault() : 0).FirstOrDefault<PurchaseOrder>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PurchaseOrderId. PurchaseOrder Not Found.");
            }
            PurchaseOrder entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetPurchaseOrderByPurchaseOrderId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

