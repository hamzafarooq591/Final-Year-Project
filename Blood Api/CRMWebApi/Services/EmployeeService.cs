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

    public class EmployeeService : IEmployeeService
    {
        public EmployeeViewModel CreateEmployee(EmployeeBindingModel model, int userId)
        {
            Employee entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            EmployeeViewModel model2 = new EmployeeViewModel();
            EmployeeRepository repository = new EmployeeRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteEmployee(int EmployeeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeRepository repository = new EmployeeRepository(context);
            Employee entity = repository.FindOne(EmployeeId).FirstOrDefault<Employee>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmployeeId. Employee Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public EmployeeViewModel GetEmployeeByEmployeeId(int EmployeeId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeRepository repository = new EmployeeRepository(context);
            if (repository.FindOne(EmployeeId).FirstOrDefault<Employee>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmployeeId. Employee Not Found.");
            }
            return repository.FindOneMapped(EmployeeId);
        }

        public NashPagedList<EmployeeViewModel> GetEmployee(int rows, int pageNumber, string SearchString = "")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeRepository repository = new EmployeeRepository(context);
           SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;//serach put

            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }

        public EmployeeViewModel UpdateEmployee(EmployeeBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeRepository repository = new EmployeeRepository(context);
            int? EmployeeId = model.EmployeeId;
            Employee original = repository.FindOne(EmployeeId.HasValue ? EmployeeId.GetValueOrDefault() : 0).FirstOrDefault<Employee>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmployeeId. Employee Not Found.");
            }
            Employee entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetEmployeeByEmployeeId(entity.Id);
        }




        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}
