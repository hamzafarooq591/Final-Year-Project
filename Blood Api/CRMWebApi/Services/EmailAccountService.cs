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

    public class EmailAccountService : IEmailAccountService
    {
        public EmailAccountViewModel CreateEmailAccount(EmailAccountBindingModel model, int userId)
        {
            EmailAccount entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            EmailAccountViewModel model2 = new EmailAccountViewModel();
            EmailAccountRepository repository = new EmailAccountRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteEmailAccount(int EmailAccountId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailAccountRepository repository = new EmailAccountRepository(context);
            EmailAccount entity = repository.FindOne(EmailAccountId).FirstOrDefault<EmailAccount>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmailAccountId. EmailAccount Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public EmailAccountViewModel GetEmailAccountByEmailAccountId(int EmailAccountId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailAccountRepository repository = new EmailAccountRepository(context);
            if (repository.FindOne(EmailAccountId).FirstOrDefault<EmailAccount>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmailAccountId. EmailAccount Not Found.");
            }
            return repository.FindOneMapped(EmailAccountId);
        }

        public NashPagedList<EmailAccountViewModel> GetEmailAccount(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailAccountRepository repository = new EmailAccountRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public EmailAccountViewModel UpdateEmailAccount(EmailAccountBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmailAccountRepository repository = new EmailAccountRepository(context);
            int? EmailAccountId = model.EmailAccountId;
            EmailAccount original = repository.FindOne(EmailAccountId.HasValue ? EmailAccountId.GetValueOrDefault() : 0).FirstOrDefault<EmailAccount>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmailAccountId. EmailAccount Not Found.");
            }
            EmailAccount entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetEmailAccountByEmailAccountId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

