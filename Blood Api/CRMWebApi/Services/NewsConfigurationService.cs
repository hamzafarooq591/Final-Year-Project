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

    public class NewsConfigurationService : INewsConfigurationService
    {
        public NewsConfigurationViewModel CreateNewsConfiguration(NewsConfigurationBindingModel model, int userId)
        {
            NewsConfiguration entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            NewsConfigurationViewModel model2 = new NewsConfigurationViewModel();
            NewsConfigurationRepository repository = new NewsConfigurationRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteNewsConfiguration(int NewsConfigurationId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsConfigurationRepository repository = new NewsConfigurationRepository(context);
            NewsConfiguration entity = repository.FindOne(NewsConfigurationId).FirstOrDefault<NewsConfiguration>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsConfigurationId. NewsConfiguration Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public NewsConfigurationViewModel GetNewsConfigurationByNewsConfigurationId(int NewsConfigurationId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsConfigurationRepository repository = new NewsConfigurationRepository(context);
            if (repository.FindOne(NewsConfigurationId).FirstOrDefault<NewsConfiguration>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsConfigurationId. NewsConfiguration Not Found.");
            }
            return repository.FindOneMapped(NewsConfigurationId);
        }

        public NashPagedList<NewsConfigurationViewModel> GetNewsConfiguration(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsConfigurationRepository repository = new NewsConfigurationRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public NewsConfigurationViewModel UpdateNewsConfiguration(NewsConfigurationBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsConfigurationRepository repository = new NewsConfigurationRepository(context);
            int? NewsConfigurationId = model.NewsConfigurationId;
            NewsConfiguration original = repository.FindOne(NewsConfigurationId.HasValue ? NewsConfigurationId.GetValueOrDefault() : 0).FirstOrDefault<NewsConfiguration>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsConfigurationId. NewsConfiguration Not Found.");
            }
            NewsConfiguration entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNewsConfigurationByNewsConfigurationId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

