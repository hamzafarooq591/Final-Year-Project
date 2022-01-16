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

    public class StaticPageService : IStaticPageService
    {
        public StaticPageViewModel CreateStaticPage(StaticPageBindingModel model, int userId)
        {
            StaticPage entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            StaticPageViewModel model2 = new StaticPageViewModel();
            StaticPageRepository repository = new StaticPageRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteStaticPage(int StaticPageId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            StaticPageRepository repository = new StaticPageRepository(context);
            StaticPage entity = repository.FindOne(StaticPageId).FirstOrDefault<StaticPage>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid StaticPageId. StaticPage Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public StaticPageViewModel GetStaticPageByStaticPageId(int StaticPageId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            StaticPageRepository repository = new StaticPageRepository(context);
            if (repository.FindOne(StaticPageId).FirstOrDefault<StaticPage>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid StaticPageId. StaticPage Not Found.");
            }
            return repository.FindOneMapped(StaticPageId);
        }

        public NashPagedList<StaticPageViewModel> GetStaticPage(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            StaticPageRepository repository = new StaticPageRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public StaticPageViewModel UpdateStaticPage(StaticPageBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            StaticPageRepository repository = new StaticPageRepository(context);
            int? StaticPageId = model.StaticPageId;
            StaticPage original = repository.FindOne(StaticPageId.HasValue ? StaticPageId.GetValueOrDefault() : 0).FirstOrDefault<StaticPage>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid StaticPageId. StaticPage Not Found.");
            }
            StaticPage entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetStaticPageByStaticPageId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

