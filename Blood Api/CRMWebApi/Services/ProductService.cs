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

    public class ProductService : IProductService
    {
        public ProductViewModel CreateProduct(ProductBindingModel model, int userId)
        {
            Product entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();

            ProductViewModel model2 = new ProductViewModel();
            ProductRepository repository = new ProductRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteProduct(int ProductId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductRepository repository = new ProductRepository(context);
            Product entity = repository.FindOne(ProductId).FirstOrDefault<Product>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductId. Product Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public ProductViewModel GetProductByProductId(int ProductId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductRepository repository = new ProductRepository(context);
            if (repository.FindOne(ProductId).FirstOrDefault<Product>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductId. Product Not Found.");
            }
            return repository.FindOneMapped(ProductId);
        }

        public NashPagedList<ProductViewModel> GetProduct(int rows, int pageNumber , string SearchString ="")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductRepository repository = new ProductRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }
        
        public ProductViewModel UpdateProduct(ProductBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductRepository repository = new ProductRepository(context);
            int? ProductId = model.ProductId;
            Product original = repository.FindOne(ProductId.HasValue ? ProductId.GetValueOrDefault() : 0).FirstOrDefault<Product>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductId. Product Not Found.");
            }
            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            Product entity = model.ToEntity(userId, original);
            
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetProductByProductId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

