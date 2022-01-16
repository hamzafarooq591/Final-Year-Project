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

    public class ProductInStoreService : IProductInStoreService
    {
        public ProductInStoreViewModel CreateProductInStore(ProductInStoreBindingModel model, int userId)
        {
            ProductInStore entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            ProductInStoreViewModel model2 = new ProductInStoreViewModel();
            ProductInStoreRepository repository = new ProductInStoreRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteProductInStore(int ProductInStoreId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductInStoreRepository repository = new ProductInStoreRepository(context);
            ProductInStore entity = repository.FindOne(ProductInStoreId).FirstOrDefault<ProductInStore>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductInStoreId. ProductInStore Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public ProductInStoreViewModel GetProductInStoreByProductInStoreId(int ProductInStoreId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductInStoreRepository repository = new ProductInStoreRepository(context);
            if (repository.FindOne(ProductInStoreId).FirstOrDefault<ProductInStore>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductInStoreId. ProductInStore Not Found.");
            }
            return repository.FindOneMapped(ProductInStoreId);
        }

        public NashPagedList<ProductInStoreViewModel> GetProductInStore(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductInStoreRepository repository = new ProductInStoreRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public ProductInStoreViewModel UpdateProductInStore(ProductInStoreBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductInStoreRepository repository = new ProductInStoreRepository(context);
            int? ProductInStoreId = model.ProductInStoreId;
            ProductInStore original = repository.FindOne(ProductInStoreId.HasValue ? ProductInStoreId.GetValueOrDefault() : 0).FirstOrDefault<ProductInStore>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductInStoreId. ProductInStore Not Found.");
            }
            ProductInStore entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetProductInStoreByProductInStoreId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

