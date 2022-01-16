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

    public class CourierCompanyService : ICourierCompanyService
    {
        public CourierCompanyViewModel CreateCourierCompany(CourierCompanyBindingModel model, int userId)
        {
            CourierCompany entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            CourierCompanyViewModel model2 = new CourierCompanyViewModel();
            CourierCompanyRepository repository = new CourierCompanyRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteCourierCompany(int CourierCompanyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CourierCompanyRepository repository = new CourierCompanyRepository(context);
            CourierCompany entity = repository.FindOne(CourierCompanyId).FirstOrDefault<CourierCompany>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CourierCompanyId. CourierCompany Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public CourierCompanyViewModel GetCourierCompanyByCourierCompanyId(int CourierCompanyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CourierCompanyRepository repository = new CourierCompanyRepository(context);
            if (repository.FindOne(CourierCompanyId).FirstOrDefault<CourierCompany>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CourierCompanyId. CourierCompany Not Found.");
            }
            return repository.FindOneMapped(CourierCompanyId);
        }

        public NashPagedList<CourierCompanyViewModel> GetCourierCompany(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CourierCompanyRepository repository = new CourierCompanyRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public CourierCompanyViewModel UpdateCourierCompany(CourierCompanyBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CourierCompanyRepository repository = new CourierCompanyRepository(context);
            int? CourierCompanyId = model.CourierCompanyId;
            CourierCompany original = repository.FindOne(CourierCompanyId.HasValue ? CourierCompanyId.GetValueOrDefault() : 0).FirstOrDefault<CourierCompany>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CourierCompanyId. CourierCompany Not Found.");
            }
            CourierCompany entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetCourierCompanyByCourierCompanyId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

