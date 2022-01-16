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

    public class OtherPaymentService : IOtherPaymentService
    {
        public OtherPaymentViewModel CreateOtherPayment(OtherPaymentBindingModel model, int userId)
        {
            OtherPayment entity = model.ToEntity(userId, null);

            ImageUpload imageUpload = new ImageUpload
            {
                fileUrl = model.ImageProofURL,
                Title = "image_" + model.PaymentTypeId,
                Description = "image_Description_" + model.PaymentTypeId,
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

            OtherPaymentViewModel model2 = new OtherPaymentViewModel();
            OtherPaymentRepository repository = new OtherPaymentRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity.ImageProofId = imageUpload.Id;
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteOtherPayment(int OtherPaymentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OtherPaymentRepository repository = new OtherPaymentRepository(context);
            OtherPayment entity = repository.FindOne(OtherPaymentId).FirstOrDefault<OtherPayment>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OtherPaymentId. OtherPayment Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public OtherPaymentViewModel GetOtherPaymentByOtherPaymentId(int OtherPaymentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OtherPaymentRepository repository = new OtherPaymentRepository(context);
            if (repository.FindOne(OtherPaymentId).FirstOrDefault<OtherPayment>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OtherPaymentId. OtherPayment Not Found.");
            }
            return repository.FindOneMapped(OtherPaymentId);
        }

        public NashPagedList<OtherPaymentViewModel> GetOtherPayment(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OtherPaymentRepository repository = new OtherPaymentRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public OtherPaymentViewModel UpdateOtherPayment(OtherPaymentBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OtherPaymentRepository repository = new OtherPaymentRepository(context);
            int? OtherPaymentId = model.OtherPaymentId;
            OtherPayment original = repository.FindOne(OtherPaymentId.HasValue ? OtherPaymentId.GetValueOrDefault() : 0).FirstOrDefault<OtherPayment>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OtherPaymentId. OtherPayment Not Found.");
            }
            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

            OtherPayment entity = model.ToEntity(userId, original);
            ImageUpload originalImageUpload = imageUploadRepository.FindOne(original.ImageProofId).FirstOrDefault();
            if (originalImageUpload == null)
            {
                ImageUpload imageUpload = new ImageUpload
                {
                    fileUrl = model.ImageProofURL,
                    Title = "image_" + model.PaymentTypeId,
                    Description = "image_Description_" + model.PaymentTypeId,
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
                entity.ImageProofId = imageUpload.Id;
            }
                using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetOtherPaymentByOtherPaymentId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

