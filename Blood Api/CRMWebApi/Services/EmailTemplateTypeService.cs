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

    public class EmailTemplateTypeService : IEmailTemplateTypeService
    {
        public EmailTemplateTypeViewModel CreateEmailTemplateType(EmailTemplateTypeBindingModel model, int userId)
        {
            EmailTemplateType entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            EmailTemplateTypeViewModel model2 = new EmailTemplateTypeViewModel();
            EmailTemplateTypeRepository repository = new EmailTemplateTypeRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteEmailTemplateType(int EmailTemplateTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailTemplateTypeRepository repository = new EmailTemplateTypeRepository(context);
            EmailTemplateType entity = repository.FindOne(EmailTemplateTypeId).FirstOrDefault<EmailTemplateType>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmailTemplateTypeId. EmailTemplateType Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public EmailTemplateTypeViewModel GetEmailTemplateTypeByEmailTemplateTypeId(int EmailTemplateTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailTemplateTypeRepository repository = new EmailTemplateTypeRepository(context);
            if (repository.FindOne(EmailTemplateTypeId).FirstOrDefault<EmailTemplateType>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmailTemplateTypeId. EmailTemplateType Not Found.");
            }
            return repository.FindOneMapped(EmailTemplateTypeId);
        }

        public NashPagedList<EmailTemplateTypeViewModel> GetEmailTemplateType(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailTemplateTypeRepository repository = new EmailTemplateTypeRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public EmailTemplateTypeViewModel UpdateEmailTemplateType(EmailTemplateTypeBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailTemplateTypeRepository repository = new EmailTemplateTypeRepository(context);
            int? EmailTemplateTypeId = model.EmailTemplateTypeId;
            EmailTemplateType original = repository.FindOne(EmailTemplateTypeId.HasValue ? EmailTemplateTypeId.GetValueOrDefault() : 0).FirstOrDefault<EmailTemplateType>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmailTemplateTypeId. EmailTemplateType Not Found.");
            }
            EmailTemplateType entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetEmailTemplateTypeByEmailTemplateTypeId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

