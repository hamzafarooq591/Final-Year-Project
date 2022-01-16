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

    public class ProductImageService : IProductImageService
    {
        public ProductImageViewModel CreateProductImage(ProductImageBindingModel model, int userId)
        {
            ProductImage entity = model.ToEntity(userId, null);

           
            NashWebApi.NashContext ImageUploadcontext = new NashWebApi.NashContext();
            NashWebApi.NashContext context = new NashWebApi.NashContext();


            ProductImageViewModel model2 = new ProductImageViewModel();
            ProductImageRepository repository = new ProductImageRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity.ImageId = model.ImageId;
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteProductImage(int ProductImageId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductImageRepository repository = new ProductImageRepository(context);
            ProductImage entity = repository.FindOne(ProductImageId).FirstOrDefault<ProductImage>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductImageId. ProductImage Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public ProductImageViewModel GetProductImageByProductImageId(int ProductImageId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductImageRepository repository = new ProductImageRepository(context);
            if (repository.FindOne(ProductImageId).FirstOrDefault<ProductImage>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductImageId. ProductImage Not Found.");
            }
            return repository.FindOneMapped(ProductImageId);
        }

        public NashPagedList<ProductImageViewModel> GetProductImage(int rows, int pageNumber, string SearchString = "")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductImageRepository repository = new ProductImageRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }

        public ProductImageViewModel UpdateProductImage(ProductImageBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ProductImageRepository repository = new ProductImageRepository(context);
            int? ProductImageId = model.ProductImageId;
            ProductImage original = repository.FindOne(ProductImageId.HasValue ? ProductImageId.GetValueOrDefault() : 0).FirstOrDefault<ProductImage>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ProductImageId. ProductImage Not Found.");
            }
            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

            ProductImage entity = model.ToEntity(userId, original);

            ImageUpload originalImageUpload = imageUploadRepository.FindOne(original.ImageId).FirstOrDefault();

            //if (originalImageUpload == null)
            //{
            //    ImageUpload imageUpload = new ImageUpload
            //    {
            //        fileUrl = model.ProductImageUpload,
            //        Title = "image_" + model.ProductImageUpload,
            //        Description = "image_Description_" + model.ProductImageUpload,
            //        CreatedByUserId = entity.CreatedByUserId,
            //        CreatedOn = entity.CreatedOn,
            //        IsDeleted = false,
            //        ModifiedByUserId = entity.ModifiedByUserId,
            //        ModifiedOn = entity.ModifiedOn
            //    };
            //    using (UnitOfWork work = new UnitOfWork(imageUploadContext))
            //    {

            //        imageUpload = imageUploadRepository.Add(imageUpload);
            //        work.Complete();
            //    }
            //    entity.ImageId = imageUpload.Id;
            //}

            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetProductImageByProductImageId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

