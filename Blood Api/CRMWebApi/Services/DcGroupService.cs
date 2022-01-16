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

    public class DcGroupService : IDcGroupService
    {
        public DcGroupViewModel CreateDcGroup(DcGroupBindingModel model, int userId)
        {
            DcGroup entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            DcGroupViewModel model2 = new DcGroupViewModel();
            DcGroupRepository repository = new DcGroupRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteDcGroup(int DcGroupId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DcGroupRepository repository = new DcGroupRepository(context);
            DcGroup entity = repository.FindOne(DcGroupId).FirstOrDefault<DcGroup>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid DcGroupId. DcGroup Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public DcGroupViewModel GetDcGroupByDcGroupId(int DcGroupId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DcGroupRepository repository = new DcGroupRepository(context);
            if (repository.FindOne(DcGroupId).FirstOrDefault<DcGroup>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid DcGroupId. DcGroup Not Found.");
            }
            return repository.FindOneMapped(DcGroupId);
        }

        public NashPagedList<DcGroupViewModel> GetDcGroup(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DcGroupRepository repository = new DcGroupRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public DcGroupViewModel UpdateDcGroup(DcGroupBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            DcGroupRepository repository = new DcGroupRepository(context);
            int? DcGroupId = model.DcGroupId;
            DcGroup original = repository.FindOne(DcGroupId.HasValue ? DcGroupId.GetValueOrDefault() : 0).FirstOrDefault<DcGroup>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid DcGroupId. DcGroup Not Found.");
            }
            DcGroup entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetDcGroupByDcGroupId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

