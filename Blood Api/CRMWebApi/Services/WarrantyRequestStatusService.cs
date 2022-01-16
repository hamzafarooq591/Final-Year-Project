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

    public class WarrantyRequestStatusService : IWarrantyRequestStatusService
    {
        public WarrantyRequestStatusViewModel CreateWarrantyRequestStatus(WarrantyRequestStatusBindingModel model, int userId)
        {
            WarrantyRequestStatus entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            WarrantyRequestStatusViewModel model2 = new WarrantyRequestStatusViewModel();
            WarrantyRequestStatusRepository repository = new WarrantyRequestStatusRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteWarrantyRequestStatus(int WarrantyRequestStatusId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyRequestStatusRepository repository = new WarrantyRequestStatusRepository(context);
            WarrantyRequestStatus entity = repository.FindOne(WarrantyRequestStatusId).FirstOrDefault<WarrantyRequestStatus>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyRequestStatusId. WarrantyRequestStatus Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public WarrantyRequestStatusViewModel GetWarrantyRequestStatusByWarrantyRequestStatusId(int WarrantyRequestStatusId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyRequestStatusRepository repository = new WarrantyRequestStatusRepository(context);
            if (repository.FindOne(WarrantyRequestStatusId).FirstOrDefault<WarrantyRequestStatus>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyRequestStatusId. WarrantyRequestStatus Not Found.");
            }
            return repository.FindOneMapped(WarrantyRequestStatusId);
        }
        //SearchByMacAddress
        //public WarrantyRequestStatusViewModel GetWarrantyStatusRequestByMacAddress(string MacAddress)
        //{
        //    NashWebApi.NashContext context = new NashWebApi.NashContext();
        //    ProductRepository repository = new ProductRepository(context);
        //    //if (repository.FindOne(MacAddress).FirstOrDefault<Employee>() == null)
        //    //{
        //    //    throw new NashHandledExceptionNotFound("Invalid EmployeeId. Employee Not Found.");
        //    //}
        //    //NashWebApi.NashContext context = new NashWebApi.NashContext();
        //    WarrantyRequestStatusRepository repositoryWRS = new WarrantyRequestStatusRepository(context);
        //    MacAddress = string.IsNullOrEmpty(MacAddress) ? "" : MacAddress;//serach put
        //    return repository.FindByMacAddress(MacAddress).ToViewModel();
        //    //return repository.FindOneMapped(EmployeeId);
        //}
        //End


        public NashPagedList<WarrantyRequestStatusViewModel> GetWarrantyRequestStatus(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyRequestStatusRepository repository = new WarrantyRequestStatusRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public WarrantyRequestStatusViewModel UpdateWarrantyRequestStatus(WarrantyRequestStatusBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            WarrantyRequestStatusRepository repository = new WarrantyRequestStatusRepository(context);
            int? WarrantyRequestStatusId = model.WarrantyRequestStatusId;
            WarrantyRequestStatus original = repository.FindOne(WarrantyRequestStatusId.HasValue ? WarrantyRequestStatusId.GetValueOrDefault() : 0).FirstOrDefault<WarrantyRequestStatus>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid WarrantyRequestStatusId. WarrantyRequestStatus Not Found.");
            }
            WarrantyRequestStatus entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetWarrantyRequestStatusByWarrantyRequestStatusId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

