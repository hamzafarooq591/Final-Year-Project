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

    public class HomePageSlideService : IHomePageSlideService
    {
        public HomePageSlideViewModel CreateHomePageSlide(HomePageSlideBindingModel model, int userId)
        {
            HomePageSlide entity = model.ToEntity(userId, null);

            ImageUpload imageUpload = new ImageUpload
            {
                fileUrl = model.SlideImage,
                Title = "image_homeSlider" ,
                Description = "image_Description_homeSlider",
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
            HomePageSlideViewModel model2 = new HomePageSlideViewModel();
            HomePageSlideRepository repository = new HomePageSlideRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity.SlideImageId = imageUpload.Id;
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteHomePageSlide(int HomePageSlideId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            HomePageSlideRepository repository = new HomePageSlideRepository(context);
            HomePageSlide entity = repository.FindOne(HomePageSlideId).FirstOrDefault<HomePageSlide>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid HomePageSlideId. HomePageSlide Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public HomePageSlideViewModel GetHomePageSlideByHomePageSlideId(int HomePageSlideId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            HomePageSlideRepository repository = new HomePageSlideRepository(context);
            if (repository.FindOne(HomePageSlideId).FirstOrDefault<HomePageSlide>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid HomePageSlideId. HomePageSlide Not Found.");
            }
            return repository.FindOneMapped(HomePageSlideId);
        }

        public NashPagedList<HomePageSlideViewModel> GetHomePageSlide(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            HomePageSlideRepository repository = new HomePageSlideRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public HomePageSlideViewModel UpdateHomePageSlide(HomePageSlideBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            HomePageSlideRepository repository = new HomePageSlideRepository(context);
            int? HomePageSlideId = model.HomePageSlideId;
            HomePageSlide original = repository.FindOne(HomePageSlideId.HasValue ? HomePageSlideId.GetValueOrDefault() : 0).FirstOrDefault<HomePageSlide>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid HomePageSlideId. HomePageSlide Not Found.");
            }
            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

            HomePageSlide entity = model.ToEntity(userId, original);

            ImageUpload originalImageUpload = imageUploadRepository.FindOne(original.SlideImageId).FirstOrDefault();

            if (originalImageUpload == null)
            {
                ImageUpload imageUpload = new ImageUpload
                {
                    fileUrl = model.SlideImage,
                    Title = "image_homeSlider",
                    Description = "image_Description_homeSlider",
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

                entity.SlideImageId = imageUpload.Id;
            }

            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetHomePageSlideByHomePageSlideId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

