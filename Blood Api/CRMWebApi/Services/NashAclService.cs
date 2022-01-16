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

    public class NashAclService : INashAclService
    {
        public NashAclViewModel CreateNashAcl(NashAclBindingModel model, int userId)
        {
            NashAcl entity = model.ToEntity(userId, null);
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashAclViewModel model2 = new NashAclViewModel();
            NashAclRepository repository = new NashAclRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteNashAcl(int NashAclId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashAclRepository repository = new NashAclRepository(context);
            NashAcl entity = repository.FindOne(NashAclId).FirstOrDefault<NashAcl>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashAclId. NashAcl Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }

        public NashAclViewModel GetNashAclByNashAclId(int NashAclId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashAclRepository repository = new NashAclRepository(context);
            if (repository.FindOne(NashAclId).FirstOrDefault<NashAcl>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashAclId. NashAcl Not Found.");
            }
            return repository.FindOneMapped(NashAclId);
        }

        public NashPagedList<NashAclViewModel> GetNashAcls(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashAclRepository repository = new NashAclRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }

        public List<NashAclViewModel> GetNashAclByNashUserId(int NashUserId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashAclRepository repository = new NashAclRepository(context);

            NashWebApi.NashContext nashUserRoleContext = new NashWebApi.NashContext();
            NashUserRoleRepository nashUserRoleRepository = new NashUserRoleRepository(nashUserRoleContext);

           var nashRoleId = nashUserRoleRepository.GetAll()
                .FirstOrDefault(x => x.NashUserId == NashUserId).NashRoleId;

            var NashAclList = repository
                .FindOneByNashRoleId(nashRoleId)
                .ToList<NashAcl>();

            List<NashAclViewModel> nashAclViewModelList = new List<NashAclViewModel>();

            foreach (NashAcl nashAcl in NashAclList)
            {
                NashAclViewModel nashAclViewModel = new NashAclViewModel();

                nashAclViewModel = nashAcl.ToViewModel();

                nashAclViewModelList.Add(nashAclViewModel);
            }

            return nashAclViewModelList;
            
        }

        public NashAclViewModel UpdateNashAcl(NashAclBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashAclRepository repository = new NashAclRepository(context);
            int? nashAclId = model.NashAclId;
            NashAcl original = repository.FindOne(nashAclId.HasValue ? nashAclId.GetValueOrDefault() : 0).FirstOrDefault<NashAcl>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid NashAclId. NashAcl Not Found.");
            }
            NashAcl entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetNashAclByNashAclId(entity.Id);
        }

        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

