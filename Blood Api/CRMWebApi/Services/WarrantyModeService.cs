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

    public class WarrantyModeService : IWarrantyModeService
    {
        public WarrantyModeViewModel CreateWarrantyMode(WarrantyModeBindingModel model, int userId)
        {
            WarrantyMode entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            WarrantyModeViewModel model2 = new WarrantyModeViewModel();
            WarrantyModeRepository repository = new WarrantyModeRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteWarrantyMode(int WarrantyModeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyModeRepository repository = new WarrantyModeRepository(context);
            WarrantyMode entity = repository.FindOne(WarrantyModeId).FirstOrDefault<WarrantyMode>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyModeId. WarrantyMode Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public WarrantyModeViewModel GetWarrantyModeByWarrantyModeId(int WarrantyModeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyModeRepository repository = new WarrantyModeRepository(context);
            if (repository.FindOne(WarrantyModeId).FirstOrDefault<WarrantyMode>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyModeId. WarrantyMode Not Found.");
            }
            return repository.FindOneMapped(WarrantyModeId);
        }

        public NashPagedList<WarrantyModeViewModel> GetWarrantyMode(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyModeRepository repository = new WarrantyModeRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public WarrantyModeViewModel UpdateWarrantyMode(WarrantyModeBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyModeRepository repository = new WarrantyModeRepository(context);
            int? WarrantyModeId = model.WarrantyModeId;
            WarrantyMode original = repository.FindOne(WarrantyModeId.HasValue ? WarrantyModeId.GetValueOrDefault() : 0).FirstOrDefault<WarrantyMode>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyModeId. WarrantyMode Not Found.");
            }
            WarrantyMode entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetWarrantyModeByWarrantyModeId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

