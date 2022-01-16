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

    public class SmsTypeService : ISmsTypeService
    {
        public SmsTypeViewModel CreateSmsType(SmsTypeBindingModel model, int userId)
        {
            SmsType entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            SmsTypeViewModel model2 = new SmsTypeViewModel();
            SmsTypeRepository repository = new SmsTypeRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteSmsType(int SmsTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SmsTypeRepository repository = new SmsTypeRepository(context);
            SmsType entity = repository.FindOne(SmsTypeId).FirstOrDefault<SmsType>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SmsTypeId. SmsType Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public SmsTypeViewModel GetSmsTypeBySmsTypeId(int SmsTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SmsTypeRepository repository = new SmsTypeRepository(context);
            if (repository.FindOne(SmsTypeId).FirstOrDefault<SmsType>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SmsTypeId. SmsType Not Found.");
            }
            return repository.FindOneMapped(SmsTypeId);
        }

        public NashPagedList<SmsTypeViewModel> GetSmsType(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SmsTypeRepository repository = new SmsTypeRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public SmsTypeViewModel UpdateSmsType(SmsTypeBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SmsTypeRepository repository = new SmsTypeRepository(context);
            int? SmsTypeId = model.SmsTypeId;
            SmsType original = repository.FindOne(SmsTypeId.HasValue ? SmsTypeId.GetValueOrDefault() : 0).FirstOrDefault<SmsType>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SmsTypeId. SmsType Not Found.");
            }
            SmsType entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetSmsTypeBySmsTypeId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

