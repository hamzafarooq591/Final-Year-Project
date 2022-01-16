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

    public class VendorPODetailService : IVendorPODetailService
    {
        public VendorPODetailViewModel CreateVendorPODetail(VendorPODetailBindingModel model, int userId)
        {
            VendorPODetail entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            VendorPODetailViewModel model2 = new VendorPODetailViewModel();
            VendorPODetailRepository repository = new VendorPODetailRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteVendorPODetail(int VendorPODetailId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorPODetailRepository repository = new VendorPODetailRepository(context);
            VendorPODetail entity = repository.FindOne(VendorPODetailId).FirstOrDefault<VendorPODetail>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid VendorPODetailId. VendorPODetail Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public VendorPODetailViewModel GetVendorPODetailByVendorPODetailId(int VendorPODetailId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorPODetailRepository repository = new VendorPODetailRepository(context);
            if (repository.FindOne(VendorPODetailId).FirstOrDefault<VendorPODetail>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid VendorPODetailId. VendorPODetail Not Found.");
            }
            return repository.FindOneMapped(VendorPODetailId);
        }

        public NashPagedList<VendorPODetailViewModel> GetVendorPODetail(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorPODetailRepository repository = new VendorPODetailRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public VendorPODetailViewModel UpdateVendorPODetail(VendorPODetailBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            VendorPODetailRepository repository = new VendorPODetailRepository(context);
            int? VendorPODetailId = model.VendorPODetailId;
            VendorPODetail original = repository.FindOne(VendorPODetailId.HasValue ? VendorPODetailId.GetValueOrDefault() : 0).FirstOrDefault<VendorPODetail>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid VendorPODetailId. VendorPODetail Not Found.");
            }
            VendorPODetail entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetVendorPODetailByVendorPODetailId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

