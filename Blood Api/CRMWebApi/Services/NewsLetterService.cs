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

    public class NewsLetterService : INewsLetterService
    {
        public NewsLetterViewModel CreateNewsLetter(NewsLetterBindingModel model, int userId)
        {
            NewsLetter entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            NewsLetterViewModel model2 = new NewsLetterViewModel();
            NewsLetterRepository repository = new NewsLetterRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteNewsLetter(int NewsLetterId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterRepository repository = new NewsLetterRepository(context);
            NewsLetter entity = repository.FindOne(NewsLetterId).FirstOrDefault<NewsLetter>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsLetterId. NewsLetter Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public NewsLetterViewModel GetNewsLetterByNewsLetterId(int NewsLetterId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterRepository repository = new NewsLetterRepository(context);
            if (repository.FindOne(NewsLetterId).FirstOrDefault<NewsLetter>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsLetterId. NewsLetter Not Found.");
            }
            return repository.FindOneMapped(NewsLetterId);
        }

        public NashPagedList<NewsLetterViewModel> GetNewsLetter(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterRepository repository = new NewsLetterRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public NewsLetterViewModel UpdateNewsLetter(NewsLetterBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterRepository repository = new NewsLetterRepository(context);
            int? NewsLetterId = model.NewsLetterId;
            NewsLetter original = repository.FindOne(NewsLetterId.HasValue ? NewsLetterId.GetValueOrDefault() : 0).FirstOrDefault<NewsLetter>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsLetterId. NewsLetter Not Found.");
            }
            NewsLetter entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNewsLetterByNewsLetterId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

