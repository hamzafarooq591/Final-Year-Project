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

    public class NewsLetterTemplateService : INewsLetterTemplateService
    {
        public NewsLetterTemplateViewModel CreateNewsLetterTemplate(NewsLetterTemplateBindingModel model, int userId)
        {
            NewsLetterTemplate entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            NewsLetterTemplateViewModel model2 = new NewsLetterTemplateViewModel();
            NewsLetterTemplateRepository repository = new NewsLetterTemplateRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteNewsLetterTemplate(int NewsLetterTemplateId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterTemplateRepository repository = new NewsLetterTemplateRepository(context);
            NewsLetterTemplate entity = repository.FindOne(NewsLetterTemplateId).FirstOrDefault<NewsLetterTemplate>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsLetterTemplateId. NewsLetterTemplate Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public NewsLetterTemplateViewModel GetNewsLetterTemplateByNewsLetterTemplateId(int NewsLetterTemplateId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterTemplateRepository repository = new NewsLetterTemplateRepository(context);
            if (repository.FindOne(NewsLetterTemplateId).FirstOrDefault<NewsLetterTemplate>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsLetterTemplateId. NewsLetterTemplate Not Found.");
            }
            return repository.FindOneMapped(NewsLetterTemplateId);
        }

        public NashPagedList<NewsLetterTemplateViewModel> GetNewsLetterTemplate(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterTemplateRepository repository = new NewsLetterTemplateRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public NewsLetterTemplateViewModel UpdateNewsLetterTemplate(NewsLetterTemplateBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterTemplateRepository repository = new NewsLetterTemplateRepository(context);
            int? NewsLetterTemplateId = model.NewsLetterTemplateId;
            NewsLetterTemplate original = repository.FindOne(NewsLetterTemplateId.HasValue ? NewsLetterTemplateId.GetValueOrDefault() : 0).FirstOrDefault<NewsLetterTemplate>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsLetterTemplateId. NewsLetterTemplate Not Found.");
            }
            NewsLetterTemplate entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNewsLetterTemplateByNewsLetterTemplateId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

