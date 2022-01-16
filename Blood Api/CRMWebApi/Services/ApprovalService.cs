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

    public class ApprovalService : IApprovalService
    {
        public ApprovalViewModel CreateApproval(ApprovalBindingModel model, int userId)
        {
            Approval entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            ApprovalViewModel model2 = new ApprovalViewModel();
            ApprovalRepository repository = new ApprovalRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteApproval(int ApprovalId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ApprovalRepository repository = new ApprovalRepository(context);
            Approval entity = repository.FindOne(ApprovalId).FirstOrDefault<Approval>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ApprovalId. Approval Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public ApprovalViewModel GetApprovalByApprovalId(int ApprovalId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ApprovalRepository repository = new ApprovalRepository(context);
            if (repository.FindOne(ApprovalId).FirstOrDefault<Approval>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ApprovalId. Approval Not Found.");
            }
            return repository.FindOneMapped(ApprovalId);
        }

        public NashPagedList<ApprovalViewModel> GetApproval(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ApprovalRepository repository = new ApprovalRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public ApprovalViewModel UpdateApproval(ApprovalBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            ApprovalRepository repository = new ApprovalRepository(context);
            int? ApprovalId = model.ApprovalId;
            Approval original = repository.FindOne(ApprovalId.HasValue ? ApprovalId.GetValueOrDefault() : 0).FirstOrDefault<Approval>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid ApprovalId. Approval Not Found.");
            }
            Approval entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetApprovalByApprovalId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

