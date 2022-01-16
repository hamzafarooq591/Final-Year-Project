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

    public class AdvanceSalaryService : IAdvanceSalaryService
    {
        public AdvanceSalaryViewModel CreateAdvanceSalary(AdvanceSalaryBindingModel model, int userId)
        {
            AdvanceSalary entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            AdvanceSalaryViewModel model2 = new AdvanceSalaryViewModel();
            AdvanceSalaryRepository repository = new AdvanceSalaryRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteAdvanceSalary(int AdvanceSalaryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AdvanceSalaryRepository repository = new AdvanceSalaryRepository(context);
            AdvanceSalary entity = repository.FindOne(AdvanceSalaryId).FirstOrDefault<AdvanceSalary>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AdvanceSalaryId. AdvanceSalary Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public AdvanceSalaryViewModel GetAdvanceSalaryByAdvanceSalaryId(int AdvanceSalaryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AdvanceSalaryRepository repository = new AdvanceSalaryRepository(context);
            if (repository.FindOne(AdvanceSalaryId).FirstOrDefault<AdvanceSalary>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AdvanceSalaryId. AdvanceSalary Not Found.");
            }
            return repository.FindOneMapped(AdvanceSalaryId);
        }

        public NashPagedList<AdvanceSalaryViewModel> GetAdvanceSalary(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AdvanceSalaryRepository repository = new AdvanceSalaryRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public AdvanceSalaryViewModel UpdateAdvanceSalary(AdvanceSalaryBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AdvanceSalaryRepository repository = new AdvanceSalaryRepository(context);
            int? AdvanceSalaryId = model.AdvanceSalaryId;
            AdvanceSalary original = repository.FindOne(AdvanceSalaryId.HasValue ? AdvanceSalaryId.GetValueOrDefault() : 0).FirstOrDefault<AdvanceSalary>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AdvanceSalaryId. AdvanceSalary Not Found.");
            }
            AdvanceSalary entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetAdvanceSalaryByAdvanceSalaryId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

