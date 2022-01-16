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

    public class DesignationService : IDesignationService
    {
        public DesignationViewModel CreateDesignation(DesignationBindingModel model, int userId)
        {
            Designation entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            DesignationViewModel model2 = new DesignationViewModel();
            DesignationRepository repository = new DesignationRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteDesignation(int DesignationId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DesignationRepository repository = new DesignationRepository(context);
            Designation entity = repository.FindOne(DesignationId).FirstOrDefault<Designation>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid DesignationId. Designation Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public DesignationViewModel GetDesignationByDesignationId(int DesignationId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DesignationRepository repository = new DesignationRepository(context);
            if (repository.FindOne(DesignationId).FirstOrDefault<Designation>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid DesignationId. Designation Not Found.");
            }
            return repository.FindOneMapped(DesignationId);
        }

        public NashPagedList<DesignationViewModel> GetDesignation(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DesignationRepository repository = new DesignationRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public DesignationViewModel UpdateDesignation(DesignationBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DesignationRepository repository = new DesignationRepository(context);
            int? DesignationId = model.DesignationId;
            Designation original = repository.FindOne(DesignationId.HasValue ? DesignationId.GetValueOrDefault() : 0).FirstOrDefault<Designation>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid DesignationId. Designation Not Found.");
            }
            Designation entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetDesignationByDesignationId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

