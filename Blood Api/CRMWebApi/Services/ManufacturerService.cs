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

    public class ManufacturerService : IManufacturerService
    {
        public ManufacturerViewModel CreateManufacturer(ManufacturerBindingModel model, int userId)
        {
            Manufacturer entity = model.ToEntity(userId, null);

            ImageUpload imageUpload = new ImageUpload
            {
                fileUrl = model.ManufacturerImageUpload,
                Title = "image_" + model.ManufacturerName,
                Description = "image_Description_" + model.ManufacturerName,
                CreatedByUserId = entity.CreatedByUserId,
                CreatedOn = entity.CreatedOn,
                IsDeleted = false,
                ModifiedByUserId = entity.ModifiedByUserId,
                ModifiedOn = entity.ModifiedOn
            };

            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashWebApi.NashContext contextImageUpload = new NashWebApi.NashContext();

            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(contextImageUpload);
            using (UnitOfWork work = new UnitOfWork(contextImageUpload))
            {
                imageUpload = imageUploadRepository.Add(imageUpload);
                work.Complete();
            }
            ManufacturerViewModel model2 = new ManufacturerViewModel();
            ManufacturerRepository repository = new ManufacturerRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity.ImageId = imageUpload.Id;
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteManufacturer(int manufacturerId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ManufacturerRepository repository = new ManufacturerRepository(context);
            Manufacturer entity = repository.FindOne(manufacturerId).FirstOrDefault<Manufacturer>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ManufacturerId. Manufacturer Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public ManufacturerViewModel GetManufacturerByManufacturerId(int manufacturerId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ManufacturerRepository repository = new ManufacturerRepository(context);
            if (repository.FindOne(manufacturerId).FirstOrDefault<Manufacturer>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ManufacturerId. Manufacturer Not Found.");
            }
            return repository.FindOneMapped(manufacturerId);
        }

        public NashPagedList<ManufacturerViewModel> GetManufacturer(int rows, int pageNumber , string SearchString ="")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ManufacturerRepository repository = new ManufacturerRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }
        
        public ManufacturerViewModel UpdateManufacturer(ManufacturerBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ManufacturerRepository repository = new ManufacturerRepository(context);
            int? manufacturerId = model.ManufacturerId;
            Manufacturer original = repository.FindOne(manufacturerId.HasValue ? manufacturerId.GetValueOrDefault() : 0).FirstOrDefault<Manufacturer>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ManufacturerId. Manufacturer Not Found.");
            }
            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

            Manufacturer entity = model.ToEntity(userId, original);

            ImageUpload originalImageUpload = imageUploadRepository.FindOne(original.ImageId).FirstOrDefault();

            if (originalImageUpload != null)
            {
                ImageUpload imageUpload = new ImageUpload
                {
                    fileUrl = model.ManufacturerImageUpload,
                    Title = "image_" + model.ManufacturerName,
                    Description = "image_Description_" + model.ManufacturerName,
                    CreatedByUserId = entity.CreatedByUserId,
                    CreatedOn = entity.CreatedOn,
                    IsDeleted = false,
                    ModifiedByUserId = entity.ModifiedByUserId,
                    ModifiedOn = entity.ModifiedOn
                };
                using (UnitOfWork work = new UnitOfWork(imageUploadContext))
                {

                    imageUpload = imageUploadRepository.Add(imageUpload);
                    work.Complete();
                }
                entity.ImageId = imageUpload.Id;
            }

            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetManufacturerByManufacturerId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

