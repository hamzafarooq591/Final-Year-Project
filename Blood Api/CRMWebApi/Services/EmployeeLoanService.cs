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

    public class EmployeeLoanService : IEmployeeLoanService
    {
        public EmployeeLoanViewModel CreateEmployeeLoan(EmployeeLoanBindingModel model, int userId)
        {
            EmployeeLoan entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            EmployeeLoanViewModel model2 = new EmployeeLoanViewModel();
            EmployeeLoanRepository repository = new EmployeeLoanRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteEmployeeLoan(int EmployeeLoanId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeLoanRepository repository = new EmployeeLoanRepository(context);
            EmployeeLoan entity = repository.FindOne(EmployeeLoanId).FirstOrDefault<EmployeeLoan>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmployeeLoanId. EmployeeLoan Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public EmployeeLoanViewModel GetEmployeeLoanByEmployeeLoanId(int EmployeeLoanId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeLoanRepository repository = new EmployeeLoanRepository(context);
            if (repository.FindOne(EmployeeLoanId).FirstOrDefault<EmployeeLoan>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmployeeLoanId. EmployeeLoan Not Found.");
            }
            return repository.FindOneMapped(EmployeeLoanId);
        }

        public NashPagedList<EmployeeLoanViewModel> GetEmployeeLoan(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeLoanRepository repository = new EmployeeLoanRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }

        public EmployeeLoanViewModel UpdateEmployeeLoan(EmployeeLoanBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeLoanRepository repository = new EmployeeLoanRepository(context);
            int? EmployeeLoanId = model.EmployeeLoanId;
            EmployeeLoan original = repository.FindOne(EmployeeLoanId.HasValue ? EmployeeLoanId.GetValueOrDefault() : 0).FirstOrDefault<EmployeeLoan>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmployeeLoanId. EmployeeLoan Not Found.");
            }
            EmployeeLoan entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetEmployeeLoanByEmployeeLoanId(entity.Id);
        }




        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}