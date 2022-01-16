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

    public class PaymentTypeService : IPaymentTypeService
    {
        public PaymentTypeViewModel CreatePaymentType(PaymentTypeBindingModel model, int userId)
        {
            PaymentType entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            PaymentTypeViewModel model2 = new PaymentTypeViewModel();
            PaymentTypeRepository repository = new PaymentTypeRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeletePaymentType(int PaymentTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PaymentTypeRepository repository = new PaymentTypeRepository(context);
            PaymentType entity = repository.FindOne(PaymentTypeId).FirstOrDefault<PaymentType>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PaymentTypeId. PaymentType Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public PaymentTypeViewModel GetPaymentTypeByPaymentTypeId(int PaymentTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PaymentTypeRepository repository = new PaymentTypeRepository(context);
            if (repository.FindOne(PaymentTypeId).FirstOrDefault<PaymentType>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PaymentTypeId. PaymentType Not Found.");
            }
            return repository.FindOneMapped(PaymentTypeId);
        }

        public NashPagedList<PaymentTypeViewModel> GetPaymentType(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PaymentTypeRepository repository = new PaymentTypeRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public PaymentTypeViewModel UpdatePaymentType(PaymentTypeBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PaymentTypeRepository repository = new PaymentTypeRepository(context);
            int? PaymentTypeId = model.PaymentTypeId;
            PaymentType original = repository.FindOne(PaymentTypeId.HasValue ? PaymentTypeId.GetValueOrDefault() : 0).FirstOrDefault<PaymentType>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PaymentTypeId. PaymentType Not Found.");
            }
            PaymentType entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetPaymentTypeByPaymentTypeId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

