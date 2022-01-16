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

    public class WarrantyService : IWarrantyService
    {
        public WarrantyViewModel CreateWarranty(WarrantyBindingModel model, int userId)
        {
            Warranty entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            WarrantyViewModel model2 = new WarrantyViewModel();
            WarrantyRepository repository = new WarrantyRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteWarranty(int WarrantyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyRepository repository = new WarrantyRepository(context);
            Warranty entity = repository.FindOne(WarrantyId).FirstOrDefault<Warranty>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyId. Warranty Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public WarrantyViewModel GetWarrantyByWarrantyId(int WarrantyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyRepository repository = new WarrantyRepository(context);
            if (repository.FindOne(WarrantyId).FirstOrDefault<Warranty>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyId. Warranty Not Found.");
            }
            return repository.FindOneMapped(WarrantyId);
        }

        public NashPagedList<WarrantyViewModel> GetWarranty(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyRepository repository = new WarrantyRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public WarrantyViewModel UpdateWarranty(WarrantyBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyRepository repository = new WarrantyRepository(context);
            int? WarrantyId = model.WarrantyId;
            Warranty original = repository.FindOne(WarrantyId.HasValue ? WarrantyId.GetValueOrDefault() : 0).FirstOrDefault<Warranty>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyId. Warranty Not Found.");
            }
            Warranty entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetWarrantyByWarrantyId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

