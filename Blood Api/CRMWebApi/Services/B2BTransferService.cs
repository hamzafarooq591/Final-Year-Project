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

    public class B2BTransferService : IB2BTransferService
    {
        public B2BTransferViewModel CreateB2BTransfer(B2BTransferBindingModel model, int userId)
        {
            B2BTransfer entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            B2BTransferViewModel model2 = new B2BTransferViewModel();
            B2BTransferRepository repository = new B2BTransferRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteB2BTransfer(int B2BTransferId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            B2BTransferRepository repository = new B2BTransferRepository(context);
            B2BTransfer entity = repository.FindOne(B2BTransferId).FirstOrDefault<B2BTransfer>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid B2BTransferId. B2BTransfer Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public B2BTransferViewModel GetB2BTransferByB2BTransferId(int B2BTransferId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            B2BTransferRepository repository = new B2BTransferRepository(context);
            if (repository.FindOne(B2BTransferId).FirstOrDefault<B2BTransfer>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid B2BTransferId. B2BTransfer Not Found.");
            }
            return repository.FindOneMapped(B2BTransferId);
        }

        public NashPagedList<B2BTransferViewModel> GetB2BTransfer(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            B2BTransferRepository repository = new B2BTransferRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public B2BTransferViewModel UpdateB2BTransfer(B2BTransferBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            B2BTransferRepository repository = new B2BTransferRepository(context);
            int? B2BTransferId = model.B2BTransferId;
            B2BTransfer original = repository.FindOne(B2BTransferId.HasValue ? B2BTransferId.GetValueOrDefault() : 0).FirstOrDefault<B2BTransfer>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid B2BTransferId. B2BTransfer Not Found.");
            }
            B2BTransfer entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetB2BTransferByB2BTransferId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

