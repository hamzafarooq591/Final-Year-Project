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

    public class SaleDeliveryItemService : ISaleDeliveryItemService
    {
        public SaleDeliveryItemViewModel CreateSaleDeliveryItem(SaleDeliveryItemBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashWebApi.NashContext accContext = new NashWebApi.NashContext();
            
            SaleDeliveryItem entity = model.ToEntity(userId, null);
            
            SaleDeliveryItemViewModel model2 = new SaleDeliveryItemViewModel();
            SaleDeliveryItemRepository repository = new SaleDeliveryItemRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteSaleDeliveryItem(int SaleDeliveryItemId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SaleDeliveryItemRepository repository = new SaleDeliveryItemRepository(context);
            SaleDeliveryItem entity = repository.FindOne(SaleDeliveryItemId).FirstOrDefault<SaleDeliveryItem>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SaleDeliveryItemId. SaleDeliveryItem Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public SaleDeliveryItemViewModel GetSaleDeliveryItemBySaleDeliveryItemId(int SaleDeliveryItemId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SaleDeliveryItemRepository repository = new SaleDeliveryItemRepository(context);
            if (repository.FindOne(SaleDeliveryItemId).FirstOrDefault<SaleDeliveryItem>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SaleDeliveryItemId. SaleDeliveryItem Not Found.");
            }
            return repository.FindOneMapped(SaleDeliveryItemId);
        }

        public NashPagedList<SaleDeliveryItemViewModel> GetSaleDeliveryItemBySaleDeliveryId(int rows, int pageNumber, int SaleDeliveryId)
        {

            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SaleDeliveryItemRepository repository = new SaleDeliveryItemRepository(context);
            
            return repository.FilterBySaleDeliveryId(rows,pageNumber,SaleDeliveryId).ToViewModel();
        }

        public NashPagedList<SaleDeliveryItemViewModel> GetSaleDeliveryItem(int rows, int pageNumber, bool? isCompleted = null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SaleDeliveryItemRepository repository = new SaleDeliveryItemRepository(context);
            return repository.Filter(rows, pageNumber,isCompleted).ToViewModel();
        }
        
        public SaleDeliveryItemViewModel UpdateSaleDeliveryItem(SaleDeliveryItemBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SaleDeliveryItemRepository repository = new SaleDeliveryItemRepository(context);
            int? SaleDeliveryItemId = model.SaleDeliveryItemId;
            SaleDeliveryItem original = repository.FindOne(SaleDeliveryItemId.HasValue ? SaleDeliveryItemId.GetValueOrDefault() : 0).FirstOrDefault<SaleDeliveryItem>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SaleDeliveryItemId. SaleDeliveryItem Not Found.");
            }
            SaleDeliveryItem entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetSaleDeliveryItemBySaleDeliveryItemId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

