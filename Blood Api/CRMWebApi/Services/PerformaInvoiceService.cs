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

    public class PerformaInvoiceService : IPerformaInvoiceService
    {
        public PerformaInvoiceViewModel CreatePerformaInvoice(PerformaInvoiceBindingModel model, int userId)
        {
            PerformaInvoice entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            PerformaInvoiceViewModel model2 = new PerformaInvoiceViewModel();
            PerformaInvoiceRepository repository = new PerformaInvoiceRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeletePerformaInvoice(int PerformaInvoiceId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PerformaInvoiceRepository repository = new PerformaInvoiceRepository(context);
            PerformaInvoice entity = repository.FindOne(PerformaInvoiceId).FirstOrDefault<PerformaInvoice>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PerformaInvoiceId. PerformaInvoice Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public PerformaInvoiceViewModel GetPerformaInvoiceByPerformaInvoiceId(int PerformaInvoiceId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PerformaInvoiceRepository repository = new PerformaInvoiceRepository(context);
            if (repository.FindOne(PerformaInvoiceId).FirstOrDefault<PerformaInvoice>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PerformaInvoiceId. PerformaInvoice Not Found.");
            }
            return repository.FindOneMapped(PerformaInvoiceId);
        }

        public NashPagedList<PerformaInvoiceViewModel> GetPerformaInvoice(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PerformaInvoiceRepository repository = new PerformaInvoiceRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public PerformaInvoiceViewModel UpdatePerformaInvoice(PerformaInvoiceBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PerformaInvoiceRepository repository = new PerformaInvoiceRepository(context);
            int? PerformaInvoiceId = model.PerformaInvoiceId;
            PerformaInvoice original = repository.FindOne(PerformaInvoiceId.HasValue ? PerformaInvoiceId.GetValueOrDefault() : 0).FirstOrDefault<PerformaInvoice>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PerformaInvoiceId. PerformaInvoice Not Found.");
            }
            PerformaInvoice entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetPerformaInvoiceByPerformaInvoiceId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

