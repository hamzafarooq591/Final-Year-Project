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

    public class PageContentService : IPageContentService
    {
        public PageContentViewModel CreatePageContent(PageContentBindingModel model, int userId)
        {
            PageContent entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            PageContentViewModel model2 = new PageContentViewModel();
            PageContentRepository repository = new PageContentRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeletePageContent(int PageContentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PageContentRepository repository = new PageContentRepository(context);
            PageContent entity = repository.FindOne(PageContentId).FirstOrDefault<PageContent>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PageContentId. PageContent Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public PageContentViewModel GetPageContentByPageContentId(int PageContentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PageContentRepository repository = new PageContentRepository(context);
            if (repository.FindOne(PageContentId).FirstOrDefault<PageContent>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PageContentId. PageContent Not Found.");
            }
            return repository.FindOneMapped(PageContentId);
        }

        public NashPagedList<PageContentViewModel> GetPageContent(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PageContentRepository repository = new PageContentRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public PageContentViewModel UpdatePageContent(PageContentBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PageContentRepository repository = new PageContentRepository(context);
            int? PageContentId = model.PageContentId;
            PageContent original = repository.FindOne(PageContentId.HasValue ? PageContentId.GetValueOrDefault() : 0).FirstOrDefault<PageContent>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PageContentId. PageContent Not Found.");
            }
            PageContent entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetPageContentByPageContentId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

