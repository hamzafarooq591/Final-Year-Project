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

    public class BranchService : IBranchService
    {
        public BranchViewModel CreateBranch(BranchBindingModel model, int userId)
        {
            Branch entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            BranchViewModel model2 = new BranchViewModel();
            BranchRepository repository = new BranchRepository(context);
            Branch branch = repository.GetAll().
                FirstOrDefault(x=>x.BranchName.Contains(entity.BranchName));
            using (UnitOfWork work = new UnitOfWork(context))
            {
                if (branch != null)
                {
                    throw new NashHandledExceptionNotFound("Branch Name already Exist, Try another Name");
                }
                else
                {
                    entity = repository.Add(entity);
                    work.Complete();
                    return repository.FindOneMapped(entity.Id);
                }
            }
        }

        public bool DeleteBranch(int BranchId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BranchRepository repository = new BranchRepository(context);
            AccountRepository accountRepository = new AccountRepository(context);
            Branch entity = repository.FindOne(BranchId).FirstOrDefault<Branch>();
            Account account = accountRepository.GetAll()
                .FirstOrDefault(x => x.BranchId == entity.Id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BranchId. Branch Not Found.");
            }

            if (account != null)
            {
                return false;
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public BranchViewModel GetBranchByBranchId(int BranchId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BranchRepository repository = new BranchRepository(context);
            if (repository.FindOne(BranchId).FirstOrDefault<Branch>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BranchId. Branch Not Found.");
            }
            return repository.FindOneMapped(BranchId);
        }

        public NashPagedList<BranchViewModel> GetBranch(int rows, int pageNumber , int? CompanyId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BranchRepository repository = new BranchRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, CompanyId).ToViewModel();
        }
        
        public BranchViewModel UpdateBranch(BranchBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            BranchRepository repository = new BranchRepository(context);
            int? BranchId = model.BranchId;
            Branch original = repository.FindOne(BranchId.HasValue ? BranchId.GetValueOrDefault() : 0).FirstOrDefault<Branch>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid BranchId. Branch Not Found.");
            }
            Branch entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetBranchByBranchId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

