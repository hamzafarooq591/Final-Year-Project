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

    public class PayToTypeService : IPayToTypeService
    {
        public PayToTypeViewModel CreatePayToType(PayToTypeBindingModel model, int userId)
        {
            PayToType entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            PayToTypeViewModel model2 = new PayToTypeViewModel();
            PayToTypeRepository repository = new PayToTypeRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeletePayToType(int PayToTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PayToTypeRepository repository = new PayToTypeRepository(context);
            PayToType entity = repository.FindOne(PayToTypeId).FirstOrDefault<PayToType>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PayToTypeId. PayToType Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public PayToTypeViewModel GetPayToTypeByPayToTypeId(int PayToTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PayToTypeRepository repository = new PayToTypeRepository(context);
            if (repository.FindOne(PayToTypeId).FirstOrDefault<PayToType>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PayToTypeId. PayToType Not Found.");
            }
            return repository.FindOneMapped(PayToTypeId);
        }

        public NashPagedList<PayToTypeViewModel> GetPayToType(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PayToTypeRepository repository = new PayToTypeRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public PayToTypeViewModel UpdatePayToType(PayToTypeBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PayToTypeRepository repository = new PayToTypeRepository(context);
            int? PayToTypeId = model.PayToTypeId;
            PayToType original = repository.FindOne(PayToTypeId.HasValue ? PayToTypeId.GetValueOrDefault() : 0).FirstOrDefault<PayToType>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PayToTypeId. PayToType Not Found.");
            }
            PayToType entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetPayToTypeByPayToTypeId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

