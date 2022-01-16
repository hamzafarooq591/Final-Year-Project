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

    public class CompanySettingService : ICompanySettingService
    {
        public CompanySettingViewModel CreateCompanySetting(CompanySettingBindingModel model, int userId)
        {
            CompanySetting entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            CompanySettingViewModel model2 = new CompanySettingViewModel();
            CompanySettingRepository repository = new CompanySettingRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteCompanySetting(int CompanySettingId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CompanySettingRepository repository = new CompanySettingRepository(context);
            CompanySetting entity = repository.FindOne(CompanySettingId).FirstOrDefault<CompanySetting>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CompanySettingId. CompanySetting Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public CompanySettingViewModel GetCompanySettingByCompanySettingId(int CompanySettingId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CompanySettingRepository repository = new CompanySettingRepository(context);
            if (repository.FindOne(CompanySettingId).FirstOrDefault<CompanySetting>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CompanySettingId. CompanySetting Not Found.");
            }
            return repository.FindOneMapped(CompanySettingId);
        }

        public NashPagedList<CompanySettingViewModel> GetCompanySetting(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CompanySettingRepository repository = new CompanySettingRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public CompanySettingViewModel UpdateCompanySetting(CompanySettingBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CompanySettingRepository repository = new CompanySettingRepository(context);
            int? CompanySettingId = model.CompanySettingId;
            CompanySetting original = repository.FindOne(CompanySettingId.HasValue ? CompanySettingId.GetValueOrDefault() : 0).FirstOrDefault<CompanySetting>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CompanySettingId. CompanySetting Not Found.");
            }
            CompanySetting entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetCompanySettingByCompanySettingId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

