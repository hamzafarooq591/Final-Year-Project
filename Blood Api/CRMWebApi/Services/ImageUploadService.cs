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
    using System.Linq;

    public class ImageUploadService : IImageUploadService
    {
        public ImageUploadViewModel CreateImageUpload(ImageUploadBindingModel model, int userId)
        {
            ImageUpload entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ImageUploadViewModel model2 = new ImageUploadViewModel();
            ImageUploadRepository repository = new ImageUploadRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteImageUpload(int ImageUploadId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ImageUploadRepository repository = new ImageUploadRepository(context);
            ImageUpload entity = repository.FindOne(ImageUploadId).FirstOrDefault<ImageUpload>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ImageUploadId. ImageUpload Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public NashPagedList<ImageUploadViewModel> GetImageUploads(int rows, int pageNumber)
        {
            ImageUploadRepository repository = new ImageUploadRepository(new NashWebApi.NashContext());
            return repository.Filter(rows, pageNumber).ToViewModel();
        }

        public ImageUploadViewModel GetImageUploadByImageUploadId(int ImageUploadId)
        {
            ImageUploadRepository repository = new ImageUploadRepository(new NashWebApi.NashContext());
            if (repository.FindOne(ImageUploadId).FirstOrDefault<ImageUpload>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ImageUploadId. ImageUpload Not Found.");
            }
            return repository.FindOneMapped(ImageUploadId);
        }

        public ImageUploadViewModel UpdateImageUpload(ImageUploadBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ImageUploadRepository repository = new ImageUploadRepository(context);
            int? ImageUploadId = model.ImageUploadId;
            ImageUpload original = repository.FindOne(ImageUploadId.HasValue ? ImageUploadId.GetValueOrDefault() : 0).FirstOrDefault<ImageUpload>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ImageUploadId. ImageUpload Not Found.");
            }
            ImageUpload entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetImageUploadByImageUploadId(entity.Id);
        }

        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

