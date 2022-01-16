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

    public class ItemService : IItemService
    {
        public ItemViewModel CreateItem(ItemBindingModel model, int userId)
        {
            Item entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            ItemViewModel model2 = new ItemViewModel();
            ItemRepository repository = new ItemRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteItem(int ItemId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ItemRepository repository = new ItemRepository(context);
            Item entity = repository.FindOne(ItemId).FirstOrDefault<Item>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ItemId. Item Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public ItemViewModel GetItemByItemId(int ItemId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ItemRepository repository = new ItemRepository(context);
            if (repository.FindOne(ItemId).FirstOrDefault<Item>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ItemId. Item Not Found.");
            }
            return repository.FindOneMapped(ItemId);
        }

        public NashPagedList<ItemViewModel> GetItem(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ItemRepository repository = new ItemRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public ItemViewModel UpdateItem(ItemBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ItemRepository repository = new ItemRepository(context);
            int? ItemId = model.ItemId;
            Item original = repository.FindOne(ItemId.HasValue ? ItemId.GetValueOrDefault() : 0).FirstOrDefault<Item>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ItemId. Item Not Found.");
            }
            Item entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetItemByItemId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

