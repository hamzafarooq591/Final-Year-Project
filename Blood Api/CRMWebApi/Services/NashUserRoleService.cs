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
    using System.Linq;

    public class NashUserRoleService : INashUserRoleService
    {
        public NashUserRoleViewModel CreateNashUserRole(NashUserRoleBindingModel model, int userId)
        {
            NashUserRole entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRoleViewModel model2 = new NashUserRoleViewModel();
            NashUserRoleRepository repository = new NashUserRoleRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteNashUserRole(int NashUserRoleId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRoleRepository repository = new NashUserRoleRepository(context);
            NashUserRole entity = repository.FindOne(NashUserRoleId).FirstOrDefault<NashUserRole>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashUserRoleId. NashUserRole Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public NashUserRoleViewModel GetNashUserRoleByNashUserRoleId(int NashUserRoleId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRoleRepository repository = new NashUserRoleRepository(context);
            if (repository.FindOne(NashUserRoleId).FirstOrDefault<NashUserRole>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashUserRoleId. NashUserRole Not Found.");
            }
            return repository.FindOneMapped(NashUserRoleId);
        }

        public NashPagedList<NashUserRoleViewModel> GetNashUserRoles(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRoleRepository repository = new NashUserRoleRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }

        public NashUserRoleViewModel UpdateNashUserRole(NashUserRoleBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRoleRepository repository = new NashUserRoleRepository(context);
            int? nashUserRoleId = model.NashUserRoleId;
            NashUserRole original = repository.FindOne(nashUserRoleId.HasValue ? nashUserRoleId.GetValueOrDefault() : 0).FirstOrDefault<NashUserRole>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashUserRoleId. NashUserRole Not Found.");
            }
            NashUserRole entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNashUserRoleByNashUserRoleId(entity.Id);
        }

        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

