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

    public class SellOrderService : ISellOrderService
    {
        public SellOrderViewModel CreateSellOrder(SellOrderBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            
            
            SellOrder entity = model.ToEntity(userId, null);

            entity.ReminingWeight = entity.QuantityinWeight;
            
            SellOrderViewModel model2 = new SellOrderViewModel();
            SellOrderRepository repository = new SellOrderRepository(context);
            var sellOrderViewModel = new SellOrderViewModel();

            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                sellOrderViewModel =  repository.FindOneMapped(entity.Id);
            }

            //NashWebApi.NashContext purchaseContext = new NashWebApi.NashContext();
            //PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository(purchaseContext);
            //PurchaseOrder purchaseOrder = purchaseOrderRepository.Get(model.PurchaseOrderId);
            
            //using (UnitOfWork work = new UnitOfWork(purchaseContext))
            //{
                
            //    purchaseOrder.ReminingWeight = purchaseOrder.QuantityinWeight - model.QuantityinWeight;

            //    purchaseOrderRepository.Edit(purchaseOrder);
            //    work.Complete();
            //}
            
            return sellOrderViewModel;
        }

        public bool DeleteSellOrder(int SellOrderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SellOrderRepository repository = new SellOrderRepository(context);
            SellOrder entity = repository.FindOne(SellOrderId).FirstOrDefault<SellOrder>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SellOrderId. SellOrder Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public SellOrderViewModel GetSellOrderBySellOrderId(int SellOrderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SellOrderRepository repository = new SellOrderRepository(context);
            if (repository.FindOne(SellOrderId).FirstOrDefault<SellOrder>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SellOrderId. SellOrder Not Found.");
            }
            return repository.FindOneMapped(SellOrderId);
        }

        public NashPagedList<SellOrderViewModel> GetSellOrder(int rows, int pageNumber, bool? isCompleted = null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SellOrderRepository repository = new SellOrderRepository(context);
            return repository.Filter(rows, pageNumber,isCompleted).ToViewModel();
        }
        
        public SellOrderViewModel UpdateSellOrder(SellOrderBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SellOrderRepository repository = new SellOrderRepository(context);
            int? SellOrderId = model.SellOrderId;
            SellOrder original = repository.FindOne(SellOrderId.HasValue ? SellOrderId.GetValueOrDefault() : 0).FirstOrDefault<SellOrder>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SellOrderId. SellOrder Not Found.");
            }
            SellOrder entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }


            //NashWebApi.NashContext purchaseContext = new NashWebApi.NashContext();
            //PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository(purchaseContext);
            //PurchaseOrder purchaseOrder = purchaseOrderRepository.Get(model.PurchaseOrderId);

            //using (UnitOfWork work = new UnitOfWork(purchaseContext))
            //{

            //    purchaseOrder.ReminingWeight = purchaseOrder.QuantityinWeight - model.QuantityinWeight;

            //    purchaseOrderRepository.Edit(purchaseOrder);
            //    work.Complete();
            //}


            return this.GetSellOrderBySellOrderId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

