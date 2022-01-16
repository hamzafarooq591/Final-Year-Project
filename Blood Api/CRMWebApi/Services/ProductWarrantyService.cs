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

    public class ProductWarrantyService : IProductWarrantyService
    {
        public ProductWarrantyViewModel CreateProductWarranty(ProductWarrantyBindingModel model, int userId)
        {
            ProductWarranty entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            ProductWarrantyViewModel model2 = new ProductWarrantyViewModel();
            ProductWarrantyRepository repository = new ProductWarrantyRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteProductWarranty(int ProductWarrantyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductWarrantyRepository repository = new ProductWarrantyRepository(context);
            ProductWarranty entity = repository.FindOne(ProductWarrantyId).FirstOrDefault<ProductWarranty>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductWarrantyId. ProductWarranty Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public ProductWarrantyViewModel GetProductWarrantyByProductWarrantyId(int ProductWarrantyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductWarrantyRepository repository = new ProductWarrantyRepository(context);
            if (repository.FindOne(ProductWarrantyId).FirstOrDefault<ProductWarranty>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductWarrantyId. ProductWarranty Not Found.");
            }
            return repository.FindOneMapped(ProductWarrantyId);
        }

        public NashPagedList<ProductWarrantyViewModel> GetProductWarranty(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductWarrantyRepository repository = new ProductWarrantyRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public ProductWarrantyViewModel UpdateProductWarranty(ProductWarrantyBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductWarrantyRepository repository = new ProductWarrantyRepository(context);
            int? ProductWarrantyId = model.ProductWarrantyId;
            ProductWarranty original = repository.FindOne(ProductWarrantyId.HasValue ? ProductWarrantyId.GetValueOrDefault() : 0).FirstOrDefault<ProductWarranty>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductWarrantyId. ProductWarranty Not Found.");
            }
            ProductWarranty entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetProductWarrantyByProductWarrantyId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

