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
    using System.Linq;

    public class NashPageService : INashPageService
    {
        public NashPageViewModel CreateNashPage(NashPageBindingModel model, int userId)
        {
            NashPage entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashPageViewModel model2 = new NashPageViewModel();
            NashPageRepository repository = new NashPageRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteNashPage(int NashPageId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashPageRepository repository = new NashPageRepository(context);
            NashPage entity = repository.FindOne(NashPageId).FirstOrDefault<NashPage>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashPageId. NashPage Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public NashPageViewModel GetNashPageByNashPageId(int nashPageId)
        {
            NashPageRepository repository = new NashPageRepository(new NashWebApi.NashContext());
            if (repository.FindOne(nashPageId).FirstOrDefault<NashPage>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashPageId. NashPage Not Found.");
            }
            return repository.FindOneMapped(nashPageId);
        }

        public NashPagedList<NashPageViewModel> GetNashPages(int rows, int pageNumber)
        {
            NashPageRepository repository = new NashPageRepository(new NashWebApi.NashContext());
            return repository.Filter(rows, pageNumber).ToViewModel();
        }

        public NashPageViewModel UpdateNashPage(NashPageBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashPageRepository repository = new NashPageRepository(context);
            int? nashPageId = model.NashPageId;
            NashPage original = repository.FindOne(nashPageId.HasValue ? nashPageId.GetValueOrDefault() : 0).FirstOrDefault<NashPage>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashPageId. NashPage Not Found.");
            }
            NashPage entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNashPageByNashPageId(entity.Id);
        }

        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

