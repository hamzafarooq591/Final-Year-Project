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

    public class InvoiceDetailService : IInvoiceDetailService
    {
        public InvoiceDetailViewModel CreateInvoiceDetail(InvoiceDetailBindingModel model, int userId)
        {
            InvoiceDetail entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            InvoiceDetailViewModel model2 = new InvoiceDetailViewModel();
            InvoiceDetailRepository repository = new InvoiceDetailRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteInvoiceDetail(int InvoiceDetailId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceDetailRepository repository = new InvoiceDetailRepository(context);
            InvoiceDetail entity = repository.FindOne(InvoiceDetailId).FirstOrDefault<InvoiceDetail>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InvoiceDetailId. InvoiceDetail Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public InvoiceDetailViewModel GetInvoiceDetailByInvoiceDetailId(int InvoiceDetailId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceDetailRepository repository = new InvoiceDetailRepository(context);
            if (repository.FindOne(InvoiceDetailId).FirstOrDefault<InvoiceDetail>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InvoiceDetailId. InvoiceDetail Not Found.");
            }
            return repository.FindOneMapped(InvoiceDetailId);
        }

        public NashPagedList<InvoiceDetailViewModel> GetInvoiceDetail(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceDetailRepository repository = new InvoiceDetailRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public InvoiceDetailViewModel UpdateInvoiceDetail(InvoiceDetailBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceDetailRepository repository = new InvoiceDetailRepository(context);
            int? InvoiceDetailId = model.InvoiceDetailId;
            InvoiceDetail original = repository.FindOne(InvoiceDetailId.HasValue ? InvoiceDetailId.GetValueOrDefault() : 0).FirstOrDefault<InvoiceDetail>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InvoiceDetailId. InvoiceDetail Not Found.");
            }
            InvoiceDetail entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetInvoiceDetailByInvoiceDetailId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

