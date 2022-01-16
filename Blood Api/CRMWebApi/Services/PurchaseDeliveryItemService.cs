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

    public class PurchaseDeliveryItemService : IPurchaseDeliveryItemService
    {
        public PurchaseDeliveryItemViewModel CreatePurchaseDeliveryItem(PurchaseDeliveryItemBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashWebApi.NashContext accContext = new NashWebApi.NashContext();
            
            PurchaseDeliveryItem entity = model.ToEntity(userId, null);
            
            PurchaseDeliveryItemViewModel model2 = new PurchaseDeliveryItemViewModel();
            PurchaseDeliveryItemRepository repository = new PurchaseDeliveryItemRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeletePurchaseDeliveryItem(int PurchaseDeliveryItemId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseDeliveryItemRepository repository = new PurchaseDeliveryItemRepository(context);
            PurchaseDeliveryItem entity = repository.FindOne(PurchaseDeliveryItemId).FirstOrDefault<PurchaseDeliveryItem>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PurchaseDeliveryItemId. PurchaseDeliveryItem Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public PurchaseDeliveryItemViewModel GetPurchaseDeliveryItemByPurchaseDeliveryItemId(int PurchaseDeliveryItemId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseDeliveryItemRepository repository = new PurchaseDeliveryItemRepository(context);
            if (repository.FindOne(PurchaseDeliveryItemId).FirstOrDefault<PurchaseDeliveryItem>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PurchaseDeliveryItemId. PurchaseDeliveryItem Not Found.");
            }
            return repository.FindOneMapped(PurchaseDeliveryItemId);
        }

        public NashPagedList<PurchaseDeliveryItemViewModel> GetPurchaseDeliveryItemByPurchaseDeliveryId(int rows, int pageNumber, int PurchaseDeliveryId)
        {

            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseDeliveryItemRepository repository = new PurchaseDeliveryItemRepository(context);
            
            return repository.FilterByPurchaseDeliveryId(rows,pageNumber,PurchaseDeliveryId).ToViewModel();
        }

        public NashPagedList<PurchaseDeliveryItemViewModel> GetPurchaseDeliveryItem(int rows, int pageNumber, bool? isCompleted = null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseDeliveryItemRepository repository = new PurchaseDeliveryItemRepository(context);
            return repository.Filter(rows, pageNumber,isCompleted).ToViewModel();
        }
        
        public PurchaseDeliveryItemViewModel UpdatePurchaseDeliveryItem(PurchaseDeliveryItemBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseDeliveryItemRepository repository = new PurchaseDeliveryItemRepository(context);
            int? PurchaseDeliveryItemId = model.PurchaseDeliveryItemId;
            PurchaseDeliveryItem original = repository.FindOne(PurchaseDeliveryItemId.HasValue ? PurchaseDeliveryItemId.GetValueOrDefault() : 0).FirstOrDefault<PurchaseDeliveryItem>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PurchaseDeliveryItemId. PurchaseDeliveryItem Not Found.");
            }
            PurchaseDeliveryItem entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetPurchaseDeliveryItemByPurchaseDeliveryItemId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

