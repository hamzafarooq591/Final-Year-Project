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

    public class PaymentDetailService : IPaymentDetailService
    {
        public PaymentDetailViewModel CreatePaymentDetail(PaymentDetailBindingModel model, int userId)
        {
            PaymentDetail entity = model.ToEntity(userId, null);

            ImageUpload imageUpload = new ImageUpload
            {
                fileUrl = model.ImageProofUrl,
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

            PaymentDetailViewModel model2 = new PaymentDetailViewModel();
            PaymentDetailRepository repository = new PaymentDetailRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity.ImageProofId = imageUpload.Id;
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeletePaymentDetail(int PaymentDetailId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PaymentDetailRepository repository = new PaymentDetailRepository(context);
            PaymentDetail entity = repository.FindOne(PaymentDetailId).FirstOrDefault<PaymentDetail>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PaymentDetailId. PaymentDetail Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public PaymentDetailViewModel GetPaymentDetailByPaymentDetailId(int PaymentDetailId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PaymentDetailRepository repository = new PaymentDetailRepository(context);
            if (repository.FindOne(PaymentDetailId).FirstOrDefault<PaymentDetail>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PaymentDetailId. PaymentDetail Not Found.");
            }
            return repository.FindOneMapped(PaymentDetailId);
        }

        public NashPagedList<PaymentDetailViewModel> GetPaymentDetail(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PaymentDetailRepository repository = new PaymentDetailRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public PaymentDetailViewModel UpdatePaymentDetail(PaymentDetailBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PaymentDetailRepository repository = new PaymentDetailRepository(context);
            int? PaymentDetailId = model.PaymentDetailId;
            PaymentDetail original = repository.FindOne(PaymentDetailId.HasValue ? PaymentDetailId.GetValueOrDefault() : 0).FirstOrDefault<PaymentDetail>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PaymentDetailId. PaymentDetail Not Found.");
            }

            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

            PaymentDetail entity = model.ToEntity(userId, original);
            ImageUpload originalImageUpload = imageUploadRepository.FindOne(original.ImageProofId).FirstOrDefault();
            
            if (originalImageUpload == null)
            {
                ImageUpload imageUpload = new ImageUpload
                {
                    fileUrl = model.ImageProofUrl,
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
            return this.GetPaymentDetailByPaymentDetailId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

