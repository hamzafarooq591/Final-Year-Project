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

    public class BillToTypeService : IBillToTypeService
    {
        public BillToTypeViewModel CreateBillToType(BillToTypeBindingModel model, int userId)
        {
            BillToType entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            BillToTypeViewModel model2 = new BillToTypeViewModel();
            BillToTypeRepository repository = new BillToTypeRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteBillToType(int BillToTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BillToTypeRepository repository = new BillToTypeRepository(context);
            BillToType entity = repository.FindOne(BillToTypeId).FirstOrDefault<BillToType>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BillToTypeId. BillToType Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public BillToTypeViewModel GetBillToTypeByBillToTypeId(int BillToTypeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BillToTypeRepository repository = new BillToTypeRepository(context);
            if (repository.FindOne(BillToTypeId).FirstOrDefault<BillToType>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BillToTypeId. BillToType Not Found.");
            }
            return repository.FindOneMapped(BillToTypeId);
        }

        public NashPagedList<BillToTypeViewModel> GetBillToType(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BillToTypeRepository repository = new BillToTypeRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public BillToTypeViewModel UpdateBillToType(BillToTypeBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BillToTypeRepository repository = new BillToTypeRepository(context);
            int? BillToTypeId = model.BillToTypeId;
            BillToType original = repository.FindOne(BillToTypeId.HasValue ? BillToTypeId.GetValueOrDefault() : 0).FirstOrDefault<BillToType>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BillToTypeId. BillToType Not Found.");
            }
            BillToType entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetBillToTypeByBillToTypeId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

