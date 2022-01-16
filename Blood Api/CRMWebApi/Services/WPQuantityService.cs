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

    public class WPQuantityService : IWPQuantityService
    {
        public WPQuantityViewModel CreateWPQuantity(WPQuantityBindingModel model, int userId)
        {
            WPQuantity entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            WPQuantityViewModel model2 = new WPQuantityViewModel();
            WPQuantityRepository repository = new WPQuantityRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteWPQuantity(int WPQuantityId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WPQuantityRepository repository = new WPQuantityRepository(context);
            WPQuantity entity = repository.FindOne(WPQuantityId).FirstOrDefault<WPQuantity>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WPQuantityId. WPQuantity Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public WPQuantityViewModel GetWPQuantityByWPQuantityId(int WPQuantityId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WPQuantityRepository repository = new WPQuantityRepository(context);
            if (repository.FindOne(WPQuantityId).FirstOrDefault<WPQuantity>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WPQuantityId. WPQuantity Not Found.");
            }
            return repository.FindOneMapped(WPQuantityId);
        }

        public NashPagedList<WPQuantityViewModel> GetWPQuantity(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WPQuantityRepository repository = new WPQuantityRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public WPQuantityViewModel UpdateWPQuantity(WPQuantityBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WPQuantityRepository repository = new WPQuantityRepository(context);
            int? WPQuantityId = model.WPQuantityId;
            WPQuantity original = repository.FindOne(WPQuantityId.HasValue ? WPQuantityId.GetValueOrDefault() : 0).FirstOrDefault<WPQuantity>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WPQuantityId. WPQuantity Not Found.");
            }
            WPQuantity entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetWPQuantityByWPQuantityId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

