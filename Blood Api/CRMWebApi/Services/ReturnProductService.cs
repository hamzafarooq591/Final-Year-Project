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

    public class ReturnProductService : IReturnProductService
    {
        public ReturnProductViewModel CreateReturnProduct(ReturnProductBindingModel model, int userId)
        {
            ReturnProduct entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            ReturnProductViewModel model2 = new ReturnProductViewModel();
            ReturnProductRepository repository = new ReturnProductRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteReturnProduct(int ReturnProductId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ReturnProductRepository repository = new ReturnProductRepository(context);
            ReturnProduct entity = repository.FindOne(ReturnProductId).FirstOrDefault<ReturnProduct>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ReturnProductId. ReturnProduct Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public ReturnProductViewModel GetReturnProductByReturnProductId(int ReturnProductId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ReturnProductRepository repository = new ReturnProductRepository(context);
            if (repository.FindOne(ReturnProductId).FirstOrDefault<ReturnProduct>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ReturnProductId. ReturnProduct Not Found.");
            }
            return repository.FindOneMapped(ReturnProductId);
        }

        public NashPagedList<ReturnProductViewModel> GetReturnProduct(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ReturnProductRepository repository = new ReturnProductRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public ReturnProductViewModel UpdateReturnProduct(ReturnProductBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ReturnProductRepository repository = new ReturnProductRepository(context);
            int? ReturnProductId = model.ReturnProductId;
            ReturnProduct original = repository.FindOne(ReturnProductId.HasValue ? ReturnProductId.GetValueOrDefault() : 0).FirstOrDefault<ReturnProduct>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ReturnProductId. ReturnProduct Not Found.");
            }
            ReturnProduct entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetReturnProductByReturnProductId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

