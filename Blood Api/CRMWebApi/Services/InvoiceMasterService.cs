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

    public class InvoiceMasterService : IInvoiceMasterService
    {
        public InvoiceMasterViewModel CreateInvoiceMaster(InvoiceMasterBindingModel model, int userId)
        {
            InvoiceMaster entity = model.ToEntity(userId, null);
            ImageUpload imageUpload = new ImageUpload
            {
                fileUrl = model.ImageUploadfileUrl,
                Title = "Import Payment Invoice",
                Description = "FF/CA Image Proof",
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

            InvoiceMasterViewModel model2 = new InvoiceMasterViewModel();
            InvoiceMasterRepository repository = new InvoiceMasterRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity.ImageUploadId = imageUpload.Id;
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteInvoiceMaster(int InvoiceMasterId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceMasterRepository repository = new InvoiceMasterRepository(context);
            InvoiceMaster entity = repository.FindOne(InvoiceMasterId).FirstOrDefault<InvoiceMaster>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InvoiceMasterId. InvoiceMaster Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public InvoiceMasterViewModel GetInvoiceMasterByInvoiceMasterId(int InvoiceMasterId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceMasterRepository repository = new InvoiceMasterRepository(context);
            if (repository.FindOne(InvoiceMasterId).FirstOrDefault<InvoiceMaster>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InvoiceMasterId. InvoiceMaster Not Found.");
            }
            var invoiceMasterViewModel = repository.FindOneMapped(InvoiceMasterId);

            if (invoiceMasterViewModel.BillToTypeName.Contains("Freight Forwarder"))
            {
                FreightForwarderRepository freightForwarderRepository = new FreightForwarderRepository(context);
                invoiceMasterViewModel.BillToName = freightForwarderRepository.FindOne(invoiceMasterViewModel.BillToId).FirstOrDefault<FreightForwarder>().FFName;
                return invoiceMasterViewModel;
            }
            if (invoiceMasterViewModel.BillToTypeName.Contains("Clearing Agent"))
            {
                ClearingAgentRepository clearingAgentRepository = new ClearingAgentRepository(context);
                invoiceMasterViewModel.BillToName = clearingAgentRepository.FindOne(invoiceMasterViewModel.BillToId).FirstOrDefault<ClearingAgent>().CAName;
                return invoiceMasterViewModel;
            }
            else
            {
                return invoiceMasterViewModel;
            }
        }

        public NashPagedList<InvoiceMasterViewModel> GetInvoiceMaster(int rows, int pageNumber, int? BillToType)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceMasterRepository repository = new InvoiceMasterRepository(context);
            var invoiceMasterList = repository.Filter(rows, pageNumber, BillToType).ToViewModel();
            ClearingAgentRepository clearingAgentRepository = new ClearingAgentRepository(context);
            FreightForwarderRepository freightForwarderRepository = new FreightForwarderRepository(context);
            foreach (var invoiceMasterItem in invoiceMasterList.Data)
            {
                if (invoiceMasterItem.BillToTypeName.Contains("Freight Forwarder"))
                {
                    invoiceMasterItem.BillToName = freightForwarderRepository.FindOne(invoiceMasterItem.BillToId).FirstOrDefault<FreightForwarder>().FFName;
                    
                }
                if (invoiceMasterItem.BillToTypeName.Contains("Clearing Agent"))
                {
                    invoiceMasterItem.BillToName = clearingAgentRepository.FindOne(invoiceMasterItem.BillToId).FirstOrDefault<ClearingAgent>().CAName;
                    
                }
                
            }
            return invoiceMasterList;
        }
        
        public InvoiceMasterViewModel UpdateInvoiceMaster(InvoiceMasterBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            InvoiceMasterRepository repository = new InvoiceMasterRepository(context);
            int? InvoiceMasterId = model.InvoiceMasterId;
            InvoiceMaster original = repository.FindOne(InvoiceMasterId.HasValue ? InvoiceMasterId.GetValueOrDefault() : 0).FirstOrDefault<InvoiceMaster>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid InvoiceMasterId. InvoiceMaster Not Found.");
            }
            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

            InvoiceMaster entity = model.ToEntity(userId, original);

            ImageUpload originalImageUpload = imageUploadRepository.FindOne(original.ImageUploadId.Value).FirstOrDefault();
            //if (originalImageUpload == null)
            {
                ImageUpload imageUpload = new ImageUpload
                {
                    fileUrl = model.ImageUploadfileUrl,
                    Title = "Import Invoice Proof",
                    Description = "Proof of Invoice for FF,CA",
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
            return this.GetInvoiceMasterByInvoiceMasterId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

