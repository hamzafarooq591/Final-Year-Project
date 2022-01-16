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

    public class ClearingAgentService : IClearingAgentService
    {
        public ClearingAgentViewModel CreateClearingAgent(ClearingAgentBindingModel model, int userId)
        {
            ClearingAgent entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            ClearingAgentViewModel model2 = new ClearingAgentViewModel();
            ClearingAgentRepository repository = new ClearingAgentRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteClearingAgent(int ClearingAgentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ClearingAgentRepository repository = new ClearingAgentRepository(context);
            ClearingAgent entity = repository.FindOne(ClearingAgentId).FirstOrDefault<ClearingAgent>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ClearingAgentId. ClearingAgent Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public ClearingAgentViewModel GetClearingAgentByClearingAgentId(int ClearingAgentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ClearingAgentRepository repository = new ClearingAgentRepository(context);
            if (repository.FindOne(ClearingAgentId).FirstOrDefault<ClearingAgent>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ClearingAgentId. ClearingAgent Not Found.");
            }
            return repository.FindOneMapped(ClearingAgentId);
        }

        public NashPagedList<ClearingAgentViewModel> GetClearingAgent(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ClearingAgentRepository repository = new ClearingAgentRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public ClearingAgentViewModel UpdateClearingAgent(ClearingAgentBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ClearingAgentRepository repository = new ClearingAgentRepository(context);
            int? ClearingAgentId = model.ClearingAgentId;
            ClearingAgent original = repository.FindOne(ClearingAgentId.HasValue ? ClearingAgentId.GetValueOrDefault() : 0).FirstOrDefault<ClearingAgent>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ClearingAgentId. ClearingAgent Not Found.");
            }
            ClearingAgent entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetClearingAgentByClearingAgentId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

