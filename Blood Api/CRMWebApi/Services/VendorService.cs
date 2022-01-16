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

    public class VendorService : IVendorService
    {
        public VendorViewModel CreateVendor(VendorBindingModel model, int userId)
        {
            Vendor entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            VendorViewModel model2 = new VendorViewModel();
            VendorRepository repository = new VendorRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteVendor(int VendorId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorRepository repository = new VendorRepository(context);
            Vendor entity = repository.FindOne(VendorId).FirstOrDefault<Vendor>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid VendorId. Vendor Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public VendorViewModel GetVendorByVendorId(int VendorId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorRepository repository = new VendorRepository(context);
            if (repository.FindOne(VendorId).FirstOrDefault<Vendor>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid VendorId. Vendor Not Found.");
            }
            return repository.FindOneMapped(VendorId);
        }

        public NashPagedList<VendorViewModel> GetVendor(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorRepository repository = new VendorRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public VendorViewModel UpdateVendor(VendorBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorRepository repository = new VendorRepository(context);
            int? VendorId = model.VendorId;
            Vendor original = repository.FindOne(VendorId.HasValue ? VendorId.GetValueOrDefault() : 0).FirstOrDefault<Vendor>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid VendorId. Vendor Not Found.");
            }
            Vendor entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetVendorByVendorId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

