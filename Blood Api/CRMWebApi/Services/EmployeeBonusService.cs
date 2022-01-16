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

    public class EmployeeBonusService : IEmployeeBonusService
    {
        public EmployeeBonusViewModel CreateEmployeeBonus(EmployeeBonusBindingModel model, int userId)
        {
            EmployeeBonus entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            EmployeeBonusViewModel model2 = new EmployeeBonusViewModel();
            EmployeeBonusRepository repository = new EmployeeBonusRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteEmployeeBonus(int EmployeeBonusId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeBonusRepository repository = new EmployeeBonusRepository(context);
            EmployeeBonus entity = repository.FindOne(EmployeeBonusId).FirstOrDefault<EmployeeBonus>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmployeeBonusId. EmployeeBonus Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public EmployeeBonusViewModel GetEmployeeBonusByEmployeeBonusId(int EmployeeBonusId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeBonusRepository repository = new EmployeeBonusRepository(context);
            if (repository.FindOne(EmployeeBonusId).FirstOrDefault<EmployeeBonus>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmployeeBonusId. EmployeeBonus Not Found.");
            }
            return repository.FindOneMapped(EmployeeBonusId);
        }

        public NashPagedList<EmployeeBonusViewModel> GetEmployeeBonus(int rows, int pageNumber, string SearchString = "")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeBonusRepository repository = new EmployeeBonusRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }

        public EmployeeBonusViewModel UpdateEmployeeBonus(EmployeeBonusBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            EmployeeBonusRepository repository = new EmployeeBonusRepository(context);
            int? EmployeeBonusId = model.EmployeeBonusId;
            EmployeeBonus original = repository.FindOne(EmployeeBonusId.HasValue ? EmployeeBonusId.GetValueOrDefault() : 0).FirstOrDefault<EmployeeBonus>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid EmployeeBonusId. EmployeeBonus Not Found.");
            }
            EmployeeBonus entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetEmployeeBonusByEmployeeBonusId(entity.Id);
        }




        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}