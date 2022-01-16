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

    public class ImportPaymentService : IImportPaymentService
    {
        public ImportPaymentViewModel CreateImportPayment(ImportPaymentBindingModel model, int userId)
        {
            ImportPayment entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            ImportPaymentViewModel model2 = new ImportPaymentViewModel();
            ImportPaymentRepository repository = new ImportPaymentRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteImportPayment(int ImportPaymentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ImportPaymentRepository repository = new ImportPaymentRepository(context);
            ImportPayment entity = repository.FindOne(ImportPaymentId).FirstOrDefault<ImportPayment>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ImportPaymentId. ImportPayment Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public ImportPaymentViewModel GetImportPaymentByImportPaymentId(int ImportPaymentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ImportPaymentRepository repository = new ImportPaymentRepository(context);

            if (repository.FindOne(ImportPaymentId).FirstOrDefault<ImportPayment>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ImportPaymentId. ImportPayment Not Found.");
            }

           var importPaymentViewModel = repository.FindOneMapped(ImportPaymentId);

            if (importPaymentViewModel.PayToTypeTitle.Contains("Clearing Agent"))
            {
                ClearingAgentRepository clearingAgentRepository = new ClearingAgentRepository(context);
                importPaymentViewModel.PayToName = clearingAgentRepository.FindOne(importPaymentViewModel.PayToId).FirstOrDefault<ClearingAgent>().CAName;
            }
            if (importPaymentViewModel.PayToTypeTitle.Contains("Vendor"))
            {
                VendorRepository vendorRepository = new VendorRepository(context);
               importPaymentViewModel.PayToName = vendorRepository.FindOne(importPaymentViewModel.PayToId).FirstOrDefault<Vendor>().VendorName;
            }
            if (importPaymentViewModel.PayToTypeTitle.Contains("Freight Forwarder"))
            {
                FreightForwarderRepository freightForwarderRepository = new FreightForwarderRepository(context);
                importPaymentViewModel.PayToName = freightForwarderRepository.FindOne(importPaymentViewModel.PayToId).FirstOrDefault<FreightForwarder>().FFName;
            }


            return importPaymentViewModel;
        }

        public NashPagedList<ImportPaymentViewModel> GetImportPayment(int rows, int pageNumber, int? PayToType)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ImportPaymentRepository repository = new ImportPaymentRepository(context);
            var importListFilter = repository.Filter(rows, pageNumber, PayToType).ToViewModel();
            ClearingAgentRepository clearingAgentRepository = new ClearingAgentRepository(context);
            FreightForwarderRepository freightForwarderRepository = new FreightForwarderRepository(context);
            VendorRepository vendorRepository = new VendorRepository(context);
            foreach (var importItem in importListFilter.Data)
            {
                if (importItem.PayToTypeTitle.Contains("Clearing Agent"))
                    importItem.PayToName = clearingAgentRepository.FindOne(importItem.PayToId).FirstOrDefault<ClearingAgent>().CAName;
                if (importItem.PayToTypeTitle.Contains("Vendor"))
                    importItem.PayToName = vendorRepository.FindOne(importItem.PayToId).FirstOrDefault<Vendor>().VendorName;
                if(importItem.PayToTypeTitle.Contains("Freight Forwarder"))
                    importItem.PayToName = freightForwarderRepository.FindOne(importItem.PayToId).FirstOrDefault<FreightForwarder>().FFName;
            }

            return importListFilter;

        }
        
        public ImportPaymentViewModel UpdateImportPayment(ImportPaymentBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ImportPaymentRepository repository = new ImportPaymentRepository(context);
            int? ImportPaymentId = model.ImportPaymentId;
            ImportPayment original = repository.FindOne(ImportPaymentId.HasValue ? ImportPaymentId.GetValueOrDefault() : 0).FirstOrDefault<ImportPayment>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ImportPaymentId. ImportPayment Not Found.");
            }
            ImportPayment entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetImportPaymentByImportPaymentId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

