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

    public class DcSummaryService : IDcSummaryService
    {
        public DcSummaryViewModel CreateDcSummary(DcSummaryBindingModel model, int userId)
        {
            DcSummary entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            DcSummaryViewModel model2 = new DcSummaryViewModel();
            DcSummaryRepository repository = new DcSummaryRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteDcSummary(int DcSummaryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DcSummaryRepository repository = new DcSummaryRepository(context);
            DcSummary entity = repository.FindOne(DcSummaryId).FirstOrDefault<DcSummary>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid DcSummaryId. DcSummary Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public DcSummaryViewModel GetDcSummaryByDcSummaryId(int DcSummaryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DcSummaryRepository repository = new DcSummaryRepository(context);
            if (repository.FindOne(DcSummaryId).FirstOrDefault<DcSummary>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid DcSummaryId. DcSummary Not Found.");
            }
            return repository.FindOneMapped(DcSummaryId);
        }

        public NashPagedList<DcSummaryViewModel> GetDcSummary(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DcSummaryRepository repository = new DcSummaryRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public DcSummaryViewModel UpdateDcSummary(DcSummaryBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DcSummaryRepository repository = new DcSummaryRepository(context);
            int? DcSummaryId = model.DcSummaryId;
            DcSummary original = repository.FindOne(DcSummaryId.HasValue ? DcSummaryId.GetValueOrDefault() : 0).FirstOrDefault<DcSummary>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid DcSummaryId. DcSummary Not Found.");
            }
            DcSummary entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetDcSummaryByDcSummaryId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

