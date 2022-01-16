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

    public class MissingItemService : IMissingItemService
    {
        public MissingItemViewModel CreateMissingItem(MissingItemBindingModel model, int userId)
        {
            MissingItem entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            MissingItemViewModel model2 = new MissingItemViewModel();
            MissingItemRepository repository = new MissingItemRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteMissingItem(int MissingItemId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            MissingItemRepository repository = new MissingItemRepository(context);
            MissingItem entity = repository.FindOne(MissingItemId).FirstOrDefault<MissingItem>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid MissingItemId. MissingItem Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public MissingItemViewModel GetMissingItemByMissingItemId(int MissingItemId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            MissingItemRepository repository = new MissingItemRepository(context);
            if (repository.FindOne(MissingItemId).FirstOrDefault<MissingItem>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid MissingItemId. MissingItem Not Found.");
            }
            return repository.FindOneMapped(MissingItemId);
        }

        public NashPagedList<MissingItemViewModel> GetMissingItem(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            MissingItemRepository repository = new MissingItemRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public MissingItemViewModel UpdateMissingItem(MissingItemBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            MissingItemRepository repository = new MissingItemRepository(context);
            int? MissingItemId = model.MissingItemId;
            MissingItem original = repository.FindOne(MissingItemId.HasValue ? MissingItemId.GetValueOrDefault() : 0).FirstOrDefault<MissingItem>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid MissingItemId. MissingItem Not Found.");
            }
            MissingItem entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetMissingItemByMissingItemId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

