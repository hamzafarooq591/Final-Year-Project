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

    public class EmailSMSTemplateService : IEmailSMSTemplateService
    {
        public EmailSMSTemplateViewModel CreateEmailSMSTemplate(EmailSMSTemplateBindingModel model, int userId)
        {
            EmailSMSTemplate entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            EmailSMSTemplateViewModel model2 = new EmailSMSTemplateViewModel();
            EmailSMSTemplateRepository repository = new EmailSMSTemplateRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteEmailSMSTemplate(int EmailSMSTemplateId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailSMSTemplateRepository repository = new EmailSMSTemplateRepository(context);
            EmailSMSTemplate entity = repository.FindOne(EmailSMSTemplateId).FirstOrDefault<EmailSMSTemplate>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmailSMSTemplateId. EmailSMSTemplate Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public EmailSMSTemplateViewModel GetEmailSMSTemplateByEmailSMSTemplateId(int EmailSMSTemplateId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailSMSTemplateRepository repository = new EmailSMSTemplateRepository(context);
            if (repository.FindOne(EmailSMSTemplateId).FirstOrDefault<EmailSMSTemplate>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmailSMSTemplateId. EmailSMSTemplate Not Found.");
            }
            return repository.FindOneMapped(EmailSMSTemplateId);
        }

        public NashPagedList<EmailSMSTemplateViewModel> GetEmailSMSTemplate(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailSMSTemplateRepository repository = new EmailSMSTemplateRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public EmailSMSTemplateViewModel UpdateEmailSMSTemplate(EmailSMSTemplateBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailSMSTemplateRepository repository = new EmailSMSTemplateRepository(context);
            int? EmailSMSTemplateId = model.EmailSMSTemplateId;
            EmailSMSTemplate original = repository.FindOne(EmailSMSTemplateId.HasValue ? EmailSMSTemplateId.GetValueOrDefault() : 0).FirstOrDefault<EmailSMSTemplate>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmailSMSTemplateId. EmailSMSTemplate Not Found.");
            }
            EmailSMSTemplate entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetEmailSMSTemplateByEmailSMSTemplateId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

