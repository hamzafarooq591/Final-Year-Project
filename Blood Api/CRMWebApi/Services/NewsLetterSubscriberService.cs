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

    public class NewsLetterSubscriberService : INewsLetterSubscriberService
    {
        public NewsLetterSubscriberViewModel CreateNewsLetterSubscriber(NewsLetterSubscriberBindingModel model, int userId)
        {
            NewsLetterSubscriber entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            NewsLetterSubscriberViewModel model2 = new NewsLetterSubscriberViewModel();
            NewsLetterSubscriberRepository repository = new NewsLetterSubscriberRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteNewsLetterSubscriber(int NewsLetterSubscriberId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterSubscriberRepository repository = new NewsLetterSubscriberRepository(context);
            NewsLetterSubscriber entity = repository.FindOne(NewsLetterSubscriberId).FirstOrDefault<NewsLetterSubscriber>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsLetterSubscriberId. NewsLetterSubscriber Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public NewsLetterSubscriberViewModel GetNewsLetterSubscriberByNewsLetterSubscriberId(int NewsLetterSubscriberId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterSubscriberRepository repository = new NewsLetterSubscriberRepository(context);
            if (repository.FindOne(NewsLetterSubscriberId).FirstOrDefault<NewsLetterSubscriber>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsLetterSubscriberId. NewsLetterSubscriber Not Found.");
            }
            return repository.FindOneMapped(NewsLetterSubscriberId);
        }

        public NashPagedList<NewsLetterSubscriberViewModel> GetNewsLetterSubscriber(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterSubscriberRepository repository = new NewsLetterSubscriberRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public NewsLetterSubscriberViewModel UpdateNewsLetterSubscriber(NewsLetterSubscriberBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsLetterSubscriberRepository repository = new NewsLetterSubscriberRepository(context);
            int? NewsLetterSubscriberId = model.NewsLetterSubscriberId;
            NewsLetterSubscriber original = repository.FindOne(NewsLetterSubscriberId.HasValue ? NewsLetterSubscriberId.GetValueOrDefault() : 0).FirstOrDefault<NewsLetterSubscriber>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsLetterSubscriberId. NewsLetterSubscriber Not Found.");
            }
            NewsLetterSubscriber entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNewsLetterSubscriberByNewsLetterSubscriberId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

