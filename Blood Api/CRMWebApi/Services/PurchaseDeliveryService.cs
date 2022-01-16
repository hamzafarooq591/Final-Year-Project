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

    public class PurchaseDeliveryService : IPurchaseDeliveryService
    {
        public PurchaseDeliveryViewModel CreatePurchaseDelivery(PurchaseDeliveryBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            


            int PurchaseDeliveryId = 0;

            PurchaseDelivery entity = model.ToEntity(userId, null);
            
            PurchaseDeliveryViewModel model2 = new PurchaseDeliveryViewModel();
            PurchaseDeliveryRepository repository = new PurchaseDeliveryRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();

                PurchaseDeliveryId = entity.Id;

                model2 = repository.FindOneMapped(entity.Id);
            }

            foreach(var Item in model.PurchaseDeliveryItems)
            {
                Item.PurchaseDeliveryId = PurchaseDeliveryId;

                NashWebApi.NashContext ItemContext = new NashWebApi.NashContext();
                PurchaseDeliveryItemRepository PurchaseDeliveryItemRepository = new PurchaseDeliveryItemRepository(ItemContext);
                PurchaseDeliveryItem PurchaseDeliveryItem = Item.ToEntity(userId, null);

                using (UnitOfWork work = new UnitOfWork(ItemContext))
                {
                    PurchaseDeliveryItemRepository.Add(PurchaseDeliveryItem);
                    work.Complete();
                }

            }

            return model2;
        }

        public bool DeletePurchaseDelivery(int PurchaseDeliveryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseDeliveryRepository repository = new PurchaseDeliveryRepository(context);
            PurchaseDelivery entity = repository.FindOne(PurchaseDeliveryId).FirstOrDefault<PurchaseDelivery>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PurchaseDeliveryId. PurchaseDelivery Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public PurchaseDeliveryViewModel GetPurchaseDeliveryByPurchaseDeliveryId(int PurchaseDeliveryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseDeliveryRepository repository = new PurchaseDeliveryRepository(context);
            if (repository.FindOne(PurchaseDeliveryId).FirstOrDefault<PurchaseDelivery>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PurchaseDeliveryId. PurchaseDelivery Not Found.");
            }

            var purchaseDeliveryViewModel = repository.FindOneMapped(PurchaseDeliveryId);

            PurchaseDeliveryItemRepository purchaseDeliveryItemRepository = new PurchaseDeliveryItemRepository(context);

            purchaseDeliveryViewModel.purchaseDeliveryItems = purchaseDeliveryItemRepository.ListByPurchaseDeliveryId(PurchaseDeliveryId).ToViewModel();

            return purchaseDeliveryViewModel;
        }

        public NashPagedList<PurchaseDeliveryViewModel> GetPurchaseDelivery(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseDeliveryRepository repository = new PurchaseDeliveryRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public PurchaseDeliveryViewModel UpdatePurchaseDelivery(PurchaseDeliveryBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PurchaseDeliveryRepository repository = new PurchaseDeliveryRepository(context);
            PurchaseDeliveryViewModel model2 = new PurchaseDeliveryViewModel();
            int? PurchaseDeliveryId = model.PurchaseDeliveryId;
            PurchaseDelivery original = repository.FindOne(PurchaseDeliveryId.HasValue ? PurchaseDeliveryId.GetValueOrDefault() : 0).FirstOrDefault<PurchaseDelivery>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PurchaseDeliveryId. PurchaseDelivery Not Found.");
            }
            PurchaseDelivery entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetPurchaseDeliveryByPurchaseDeliveryId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

