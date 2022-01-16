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

    public class VendorPurchaseOrderService : IVendorPurchaseOrderService
    {
        public VendorPurchaseOrderViewModel CreateVendorPurchaseOrder(VendorPurchaseOrderBindingModel model, int userId)
        {
            VendorPurchaseOrder entity = model.ToEntity(userId, null);

            ImageUpload imageUpload = new ImageUpload
            {
                fileUrl = model.PurchaseImageUrl,
                Title = "image_" + model.SupplierInvoiceNo,
                Description = "image_Description"+ model.SupplierInvoiceNo,
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
            VendorPurchaseOrderViewModel model2 = new VendorPurchaseOrderViewModel();
            VendorPurchaseOrderRepository repository = new VendorPurchaseOrderRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity.ImageUploadId = imageUpload.Id;
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteVendorPurchaseOrder(int VendorPurchaseOrderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorPurchaseOrderRepository repository = new VendorPurchaseOrderRepository(context);
            VendorPurchaseOrder entity = repository.FindOne(VendorPurchaseOrderId).FirstOrDefault<VendorPurchaseOrder>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid VendorPurchaseOrderId. VendorPurchaseOrder Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public VendorPurchaseOrderViewModel GetVendorPurchaseOrderByVendorPurchaseOrderId(int VendorPurchaseOrderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorPurchaseOrderRepository repository = new VendorPurchaseOrderRepository(context);
            if (repository.FindOne(VendorPurchaseOrderId).FirstOrDefault<VendorPurchaseOrder>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid VendorPurchaseOrderId. VendorPurchaseOrder Not Found.");
            }
            return repository.FindOneMapped(VendorPurchaseOrderId);
        }

        public NashPagedList<VendorPurchaseOrderViewModel> GetVendorPurchaseOrder(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorPurchaseOrderRepository repository = new VendorPurchaseOrderRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public VendorPurchaseOrderViewModel UpdateVendorPurchaseOrder(VendorPurchaseOrderBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorPurchaseOrderRepository repository = new VendorPurchaseOrderRepository(context);
            int? VendorPurchaseOrderId = model.VendorPurchaseOrderId;
            VendorPurchaseOrder original = repository.FindOne(VendorPurchaseOrderId.HasValue ? VendorPurchaseOrderId.GetValueOrDefault() : 0).FirstOrDefault<VendorPurchaseOrder>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid VendorPurchaseOrderId. VendorPurchaseOrder Not Found.");
            }
            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);
            VendorPurchaseOrder entity = model.ToEntity(userId, original);
            ImageUpload originalImageUpload = imageUploadRepository.FindOne(original.ImageUploadId).FirstOrDefault();
            if (originalImageUpload == null)
            {
                ImageUpload imageUpload = new ImageUpload
                {
                    fileUrl = model.PurchaseImageUrl,
                    Title = "image_" + model.SupplierInvoiceNo,
                    Description = "image_Description" + model.SupplierInvoiceNo,
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

                entity.ImageUploadId = imageUpload.Id;
            }
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetVendorPurchaseOrderByVendorPurchaseOrderId(entity.Id);
        }

        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

