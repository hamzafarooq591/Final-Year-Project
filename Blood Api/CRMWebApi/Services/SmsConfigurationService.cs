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

    public class SmsConfigurationService : ISmsConfigurationService
    {
        public SmsConfigurationViewModel CreateSmsConfiguration(SmsConfigurationBindingModel model, int userId)
        {
            SmsConfiguration entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            SmsConfigurationViewModel model2 = new SmsConfigurationViewModel();
            SmsConfigurationRepository repository = new SmsConfigurationRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteSmsConfiguration(int SmsConfigurationId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SmsConfigurationRepository repository = new SmsConfigurationRepository(context);
            SmsConfiguration entity = repository.FindOne(SmsConfigurationId).FirstOrDefault<SmsConfiguration>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SmsConfigurationId. SmsConfiguration Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public SmsConfigurationViewModel GetSmsConfigurationBySmsConfigurationId(int SmsConfigurationId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SmsConfigurationRepository repository = new SmsConfigurationRepository(context);
            if (repository.FindOne(SmsConfigurationId).FirstOrDefault<SmsConfiguration>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SmsConfigurationId. SmsConfiguration Not Found.");
            }
            return repository.FindOneMapped(SmsConfigurationId);
        }

        public NashPagedList<SmsConfigurationViewModel> GetSmsConfiguration(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SmsConfigurationRepository repository = new SmsConfigurationRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public SmsConfigurationViewModel UpdateSmsConfiguration(SmsConfigurationBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SmsConfigurationRepository repository = new SmsConfigurationRepository(context);
            int? SmsConfigurationId = model.SmsConfigurationId;
            SmsConfiguration original = repository.FindOne(SmsConfigurationId.HasValue ? SmsConfigurationId.GetValueOrDefault() : 0).FirstOrDefault<SmsConfiguration>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SmsConfigurationId. SmsConfiguration Not Found.");
            }
            SmsConfiguration entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetSmsConfigurationBySmsConfigurationId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

