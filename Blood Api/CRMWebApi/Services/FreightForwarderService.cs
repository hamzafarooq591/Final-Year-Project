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

    public class FreightForwarderService : IFreightForwarderService
    {
        public FreightForwarderViewModel CreateFreightForwarder(FreightForwarderBindingModel model, int userId)
        {
            FreightForwarder entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            FreightForwarderViewModel model2 = new FreightForwarderViewModel();
            FreightForwarderRepository repository = new FreightForwarderRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteFreightForwarder(int FreightForwarderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            FreightForwarderRepository repository = new FreightForwarderRepository(context);
            FreightForwarder entity = repository.FindOne(FreightForwarderId).FirstOrDefault<FreightForwarder>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid FreightForwarderId. FreightForwarder Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public FreightForwarderViewModel GetFreightForwarderByFreightForwarderId(int FreightForwarderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            FreightForwarderRepository repository = new FreightForwarderRepository(context);
            if (repository.FindOne(FreightForwarderId).FirstOrDefault<FreightForwarder>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid FreightForwarderId. FreightForwarder Not Found.");
            }
            return repository.FindOneMapped(FreightForwarderId);
        }

        public NashPagedList<FreightForwarderViewModel> GetFreightForwarder(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            FreightForwarderRepository repository = new FreightForwarderRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public FreightForwarderViewModel UpdateFreightForwarder(FreightForwarderBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            FreightForwarderRepository repository = new FreightForwarderRepository(context);
            int? FreightForwarderId = model.FreightForwarderId;
            FreightForwarder original = repository.FindOne(FreightForwarderId.HasValue ? FreightForwarderId.GetValueOrDefault() : 0).FirstOrDefault<FreightForwarder>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid FreightForwarderId. FreightForwarder Not Found.");
            }
            FreightForwarder entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetFreightForwarderByFreightForwarderId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

