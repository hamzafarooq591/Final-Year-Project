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

    public class NashUserService : INashUserService
    {
        public NashUserViewModel CreateNashUser(NashUserBindingModel model, int userId)
        {
            NashUser entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserViewModel model2 = new NashUserViewModel();
            NashUserRepository repository = new NashUserRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }
        public bool DeleteNashUser(int nashUserId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRepository repository = new NashUserRepository(context);
            NashUser entity = repository.FindOne(nashUserId).FirstOrDefault<NashUser>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashUserId. NashUser Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        public IList<GenderType> GetGenderTypes()
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRepository repository = new NashUserRepository(context);
            return repository.GetGenderTypes();
        }

        public IList<NashRole> GetNashRoles()
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRepository repository = new NashUserRepository(context);
            return repository.GetNashRoles();
        }
        //NashUserType
        public NashUserTypeViewModel CreateNashUserType(NashUserTypeBindingModel model, int userId)
        {
            NashUserType entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserTypeViewModel model2 = new NashUserTypeViewModel();
            NashUserTypeRepository repository = new NashUserTypeRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }
        //End NashUserType
        public NashRolesViewModel CreateNashRoles(NashRolesBindingModel model, int userId)
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
        public bool DeleteNashRole(int RoleId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            RolesRepository repository = new RolesRepository(context);
            NashRole entity = repository.FindOne(RoleId).FirstOrDefault<NashRole>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashRoleID. NashRole Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
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
            return this.GetNashRoleByNashPageId(entity.Id);
        }
        public NashRolesViewModel GetNashRoleByNashPageId(int nashRoleId)
        {
            //NashPageRepository repository = new NashPageRepository(new NashWebApi.NashContext());
            RolesRepository repository = new RolesRepository(new NashWebApi.NashContext());

            if (repository.FindOne(nashRoleId).FirstOrDefault<NashRole>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashRoleId. NashRole Not Found.");
            }
            return repository.FindOneMapped(nashRoleId);
        }

        public NashUserViewModel GetNashUserByNashUserId(int nashUserId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRepository repository = new NashUserRepository(context);
            if (repository.FindOne(nashUserId).FirstOrDefault<NashUser>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashUserId. NashUser Not Found.");
            }
            return repository.FindOneMapped(nashUserId);
        }

        public NashPagedList<NashUserViewModel> GetNashUsers(int rows, int pageNumber, int? nashUserTypeId,string SearchString ="")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRepository repository = new NashUserRepository(context);
            return repository.Filter(rows, pageNumber, nashUserTypeId,SearchString).ToViewModel();
        }

        public IList<NashUserType> GetNashUserTypes()
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRepository repository = new NashUserRepository(context);
            return repository.GetNashUserType();
        }

        public NashUserViewModel RegisterNashUser(NashUserRegistrationBindingModel model, int userId)
        {
            NashUser entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashWebApi.NashContext nashUserRoleContext = new NashWebApi.NashContext();

            NashUserRepository repository = new NashUserRepository(context);
            NashUserRoleRepository nashUserRoleRepository = new NashUserRoleRepository(nashUserRoleContext);

            int nashRoleId = 0;

            NashUserViewModel nashUserViewModel = new NashUserViewModel();

            using (UnitOfWork work = new UnitOfWork(context))
            {

                nashRoleId =  repository.GetNashRoles()
                    .FirstOrDefault(x => x.RoleDisplayId == entity.NashUserTypeId).Id;
                entity = repository.Add(entity);
                work.Complete();
                nashUserViewModel = repository.FindOneMapped(entity.Id);
            }
            // Add new nash user to the role
            using (UnitOfWork work = new UnitOfWork(nashUserRoleContext))
            {
                NashUserRoleBindingModel nashUserRoleBindingModel = new NashUserRoleBindingModel();
                nashUserRoleBindingModel.NashUserId = nashUserViewModel.NashUserId;
                nashUserRoleBindingModel.NashRoleId = nashRoleId;
                var nashUserRoleEntity = nashUserRoleBindingModel.ToEntity(userId, null);
                nashUserRoleEntity = nashUserRoleRepository.Add(nashUserRoleEntity);
                work.Complete();
            }
            return nashUserViewModel;
        }

        public NashUserViewModel UpdateNashUser(NashUserBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRepository repository = new NashUserRepository(context);
            int? nashUserId = model.NashUserId;
            NashUser original = repository.FindOne(nashUserId.HasValue ? nashUserId.GetValueOrDefault() : 0).FirstOrDefault<NashUser>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashUserId. NashUser Not Found.");
            }
            NashUser entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNashUserByNashUserId(entity.Id);
        }


        #region "NashUserSession"

        public NashUserSessionViewModel CreateNashUserSession(NashUserSessionBindingModel model, int userId)
        {
            NashUserSession entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();

            NashUserSessionRepository repository = new NashUserSessionRepository(context);

            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }


        public NashUserSessionViewModel UpdateNashUserSession(NashUserSessionBindingModel model, int userId)
        {
            NashUserSession entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();

            NashUserSessionRepository repository = new NashUserSessionRepository(context);

            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }


        public bool DeleteNashUserSession(int NashUserSessionId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserSessionRepository repository = new NashUserSessionRepository(context);
            NashUserSession entity = repository.FindOne(NashUserSessionId).FirstOrDefault<NashUserSession>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashUserSessionId. NashUserSession Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public NashUserSessionViewModel GetNashUserSessionByNashUserSessionId(int NashUserSessionId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserSessionRepository repository = new NashUserSessionRepository(context);
            if (repository.FindOne(NashUserSessionId).FirstOrDefault<NashUserSession>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashUserSessionId. NashUserSession Not Found.");
            }
            return repository.FindOneMapped(NashUserSessionId);
        }

        public NashPagedList<NashUserSessionViewModel> GetNashUserSessionsByNashUserId
            (int rows, int pageNumber, int? NashUserId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserSessionRepository repository = new NashUserSessionRepository(context);
            return repository.Filter(rows, pageNumber, NashUserId).ToViewModel();
        }

        public NashUserSessionViewModel AuthenticateUser(AuthendicateBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserRepository repository = new NashUserRepository(context);

            var nashUser = repository.GetAll()
                .FirstOrDefault(x => x.IsDeleted == false
                && x.UserName == model.Username && x.password == model.Password);

            if (nashUser == null)
            {
                throw new NashHandledExceptionNotFound("Invalid User name and Password.");
            }

            var nashUserSessionBindingModel = new NashUserSessionBindingModel();
            var SessionDuration = NashConstants.Globals.SessionDuration;

            nashUserSessionBindingModel.NashUserId = nashUser.Id;
            nashUserSessionBindingModel.SessionDuration = SessionDuration;
            nashUserSessionBindingModel.SessionStart = DateTime.Now;
            nashUserSessionBindingModel.SessionEnd = DateTime.Now.AddMinutes(SessionDuration);
            nashUserSessionBindingModel.SessionKey = Guid.NewGuid().ToString();
            nashUserSessionBindingModel.IsExpired = false;

            var nashUserSessionViewModel = CreateNashUserSession(nashUserSessionBindingModel, userId);

            return nashUserSessionViewModel;



        }

        public bool ValidateSession(String SessionKey, int userId)
        {
            bool valid = false;
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashUserSessionRepository repository = new NashUserSessionRepository(context);
            // Validate Session Key
            NashUserSession nashUserSession = 
            repository.GetAll()
            .FirstOrDefault(x => x.SessionKey == SessionKey && 
            //(x.SessionStart <= DateTime.Now && x.SessionEnd >= DateTime.Now) &&
            x.IsDeleted == false && x.IsExpired == false);
            var nashUserSessionBindingModel = new NashUserSessionBindingModel();
            var SessionDuration = NashConstants.Globals.SessionDuration;
            if (nashUserSession == null)
            {
                //valid = true;
                 valid = false;
                 throw new NashHandledExceptionNotFound("Invalid Session.");
            }
            else
            {
                valid = true;
                // Update Session Key
                nashUserSessionBindingModel.NashUserId = nashUserSession.NashUserId;
                nashUserSessionBindingModel.SessionDuration = SessionDuration;
                nashUserSessionBindingModel.SessionStart = DateTime.Now;
                nashUserSessionBindingModel.SessionEnd = DateTime.Now.AddMinutes(SessionDuration);
                nashUserSessionBindingModel.SessionKey = nashUserSession.SessionKey;
                nashUserSessionBindingModel.IsExpired = valid;
                NashUserSession entity = nashUserSessionBindingModel.ToEntity(userId, null);
                NashWebApi.NashContext updateContext = new NashWebApi.NashContext();
                NashUserSessionRepository updateRepository = new NashUserSessionRepository(updateContext);
                using (UnitOfWork work = new UnitOfWork(updateContext))
                {
                    repository.Edit(entity);
                    work.Complete();
                }
            }

            return valid;
        }

        #endregion



        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

