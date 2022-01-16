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

    public class NashRoleService : INashRoleService
    {
        public NashRolesViewModel CreateNashRole(NashRolesBindingModel model, int userId)
        {
            NashRole entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashRolesViewModel model2 = new NashRolesViewModel();
            RolesRepository repository = new RolesRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteNashRole(int nashRoleId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            RolesRepository repository = new RolesRepository(context);
            NashRole entity = repository.FindOne(nashRoleId).FirstOrDefault<NashRole>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashRoleId. NashRole Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public NashRolesViewModel GetNashRoleByNashRoleId(int nashRoleId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            RolesRepository repository = new RolesRepository(context);
            if (repository.FindOne(nashRoleId).FirstOrDefault<NashRole>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashRoleId. NashRole Not Found.");
            }
            return repository.FindOneMapped(nashRoleId);
        }

        public NashPagedList<NashRolesViewModel> GetNashRole(int rows, int pageNumber , string SearchString ="")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            RolesRepository repository = new RolesRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }
        
        public NashRolesViewModel UpdateNashRole(NashRolesBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            RolesRepository repository = new RolesRepository(context);
            int? nashRoleId = model.NashRolesId;
            NashRole original = repository.FindOne(nashRoleId.HasValue ? nashRoleId.GetValueOrDefault() : 0).FirstOrDefault<NashRole>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashRoleId. NashRole Not Found.");
            }
            NashRole entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNashRoleByNashRoleId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

