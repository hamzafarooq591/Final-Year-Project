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

    public class InvoiceSummaryService : IInvoiceSummaryService
    {
        public InvoiceSummaryViewModel CreateInvoiceSummary(InvoiceSummaryBindingModel model, int userId)
        {
            InvoiceSummary entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            InvoiceSummaryViewModel model2 = new InvoiceSummaryViewModel();
            InvoiceSummaryRepository repository = new InvoiceSummaryRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteInvoiceSummary(int InvoiceSummaryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceSummaryRepository repository = new InvoiceSummaryRepository(context);
            InvoiceSummary entity = repository.FindOne(InvoiceSummaryId).FirstOrDefault<InvoiceSummary>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InvoiceSummaryId. InvoiceSummary Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public InvoiceSummaryViewModel GetInvoiceSummaryByInvoiceSummaryId(int InvoiceSummaryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceSummaryRepository repository = new InvoiceSummaryRepository(context);
            if (repository.FindOne(InvoiceSummaryId).FirstOrDefault<InvoiceSummary>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InvoiceSummaryId. InvoiceSummary Not Found.");
            }
            return repository.FindOneMapped(InvoiceSummaryId);
        }

        public NashPagedList<InvoiceSummaryViewModel> GetInvoiceSummary(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceSummaryRepository repository = new InvoiceSummaryRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public InvoiceSummaryViewModel UpdateInvoiceSummary(InvoiceSummaryBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceSummaryRepository repository = new InvoiceSummaryRepository(context);
            int? InvoiceSummaryId = model.InvoiceSummaryId;
            InvoiceSummary original = repository.FindOne(InvoiceSummaryId.HasValue ? InvoiceSummaryId.GetValueOrDefault() : 0).FirstOrDefault<InvoiceSummary>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InvoiceSummaryId. InvoiceSummary Not Found.");
            }
            InvoiceSummary entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetInvoiceSummaryByInvoiceSummaryId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

