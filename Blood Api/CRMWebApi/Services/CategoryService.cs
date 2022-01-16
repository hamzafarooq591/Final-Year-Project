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

    public class CategoryService : ICategoryService
    {
        public CategoryViewModel CreateCategory(CategoryBindingModel model, int userId)
        {
            Category entity = model.ToEntity(userId, null);

            ImageUpload imageUpload = new ImageUpload
            {
                fileUrl = model.CategoryImageUpload,
                Title = "image_" + model.CategoryName,
                Description = "image_Description_" + model.CategoryName,
                CreatedByUserId = entity.CreatedByUserId,
                CreatedOn = entity.CreatedOn,
                IsDeleted = false,
                ModifiedByUserId = entity.ModifiedByUserId,
                ModifiedOn = entity.ModifiedOn
            };

            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashWebApi.NashContext CategoryContext = new NashWebApi.NashContext();

            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                imageUpload = imageUploadRepository.Add(imageUpload);
                work.Complete();
            }
            CategoryViewModel model2 = new CategoryViewModel();
            CategoryRepository repository = new CategoryRepository(CategoryContext);
            using (UnitOfWork work = new UnitOfWork(CategoryContext))
            {
                entity.ImageId = imageUpload.Id;
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CategoryRepository repository = new CategoryRepository(context);
            Category entity = repository.FindOne(CategoryId).FirstOrDefault<Category>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CategoryId. Category Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public CategoryViewModel GetCategoryByCategoryId(int CategoryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CategoryRepository repository = new CategoryRepository(context);
            if (repository.FindOne(CategoryId).FirstOrDefault<Category>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CategoryId. Category Not Found.");
            }
            return repository.FindOneMapped(CategoryId);
        }

        public NashPagedList<CategoryViewModel> GetCategory(int rows, int pageNumber , string SearchString ="")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CategoryRepository repository = new CategoryRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }
        
        public CategoryViewModel UpdateCategory(CategoryBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CategoryRepository repository = new CategoryRepository(context);
            int? CategoryId = model.CategoryId;
            Category original = repository.FindOne(CategoryId.HasValue ? CategoryId.GetValueOrDefault() : 0).FirstOrDefault<Category>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CategoryId. Category Not Found.");
            }
            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

            Category entity = model.ToEntity(userId, original);

            ImageUpload originalImageUpload = imageUploadRepository.FindOne(original.ImageId).FirstOrDefault();

            if (originalImageUpload == null)
            {
                ImageUpload imageUpload = new ImageUpload
                {
                    fileUrl = model.CategoryImageUpload,
                    Title = "image_" + model.CategoryName,
                    Description = "image_Description_" + model.CategoryName,
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
            return this.GetCategoryByCategoryId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

