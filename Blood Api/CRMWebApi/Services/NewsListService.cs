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

    public class NewsListService : INewsListService
    {
        public NewsListViewModel CreateNewsList(NewsListBindingModel model, int userId)
        {
            NewsList entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            NewsListViewModel model2 = new NewsListViewModel();
            NewsListRepository repository = new NewsListRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteNewsList(int NewsListId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsListRepository repository = new NewsListRepository(context);
            NewsList entity = repository.FindOne(NewsListId).FirstOrDefault<NewsList>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsListId. NewsList Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public NewsListViewModel GetNewsListByNewsListId(int NewsListId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsListRepository repository = new NewsListRepository(context);
            if (repository.FindOne(NewsListId).FirstOrDefault<NewsList>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsListId. NewsList Not Found.");
            }
            return repository.FindOneMapped(NewsListId);
        }

        public NashPagedList<NewsListViewModel> GetNewsList(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsListRepository repository = new NewsListRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public NewsListViewModel UpdateNewsList(NewsListBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NewsListRepository repository = new NewsListRepository(context);
            int? NewsListId = model.NewsListId;
            NewsList original = repository.FindOne(NewsListId.HasValue ? NewsListId.GetValueOrDefault() : 0).FirstOrDefault<NewsList>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NewsListId. NewsList Not Found.");
            }
            NewsList entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNewsListByNewsListId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

