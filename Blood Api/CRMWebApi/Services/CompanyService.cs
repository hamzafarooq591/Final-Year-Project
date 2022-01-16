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

    public class CompanyService : ICompanyService
    {
        public CompanyViewModel CreateCompany(CompanyBindingModel model, int userId)
        {
            NashCompany entity = model.ToEntity(userId, null);

            ImageUpload imageUpload = new ImageUpload
            {
                fileUrl = model.CompanyImageUpload,
                Title = "image_" + model.Name,
                Description = "image_Description_" + model.Name,
                CreatedByUserId = entity.CreatedByUserId,
                CreatedOn = entity.CreatedOn,
                IsDeleted = false,
                ModifiedByUserId = entity.ModifiedByUserId,
                ModifiedOn = entity.ModifiedOn
            };

            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashWebApi.NashContext CompanyContext = new NashWebApi.NashContext();

            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                imageUpload = imageUploadRepository.Add(imageUpload);
                work.Complete();
            }
            CompanyViewModel model2 = new CompanyViewModel();
            CompanyRepository repository = new CompanyRepository(CompanyContext);
            NashCompany company = repository.GetAll().
                FirstOrDefault(x => x.Name.Contains(entity.Name));
            using (UnitOfWork work = new UnitOfWork(CompanyContext))
            {
                if (company != null)
                {
                    throw new NashHandledExceptionNotFound("Company Name already Exist, Try another Name");
                }
                else
                {
                    entity.ImageId = imageUpload.Id;
                    entity = repository.Add(entity);
                    work.Complete();
                    return repository.FindOneMapped(entity.Id);
                }
            }
        }

        public bool DeleteCompany(int companyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CompanyRepository repository = new CompanyRepository(context);
            BranchRepository branchRepository = new BranchRepository(context);
            NashCompany entity = repository.FindOne(companyId).FirstOrDefault<NashCompany>();
            Branch branch = branchRepository.GetAll()
                .FirstOrDefault(x => x.CompanyId == entity.Id && x.IsDeleted == false);


            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CompanyId. Company Not Found.");
            }

            if (branch != null)
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
        
        public CompanyViewModel GetCompanyByCompanyId(int companyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CompanyRepository repository = new CompanyRepository(context);
            if (repository.FindOne(companyId).FirstOrDefault<NashCompany>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CompanyId. Company Not Found.");
            }
            return repository.FindOneMapped(companyId);
        }

        public NashPagedList<CompanyViewModel> GetCompany(int rows, int pageNumber , string SearchString ="")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CompanyRepository repository = new CompanyRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }
        
        public CompanyViewModel UpdateCompany(CompanyBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CompanyRepository repository = new CompanyRepository(context);
            int? companyId = model.CompanyId;
            NashCompany original = repository.FindOne(companyId.HasValue ? companyId.GetValueOrDefault() : 0).FirstOrDefault<NashCompany>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid companyId. Company Not Found.");
            }
            NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
            ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

            NashCompany entity = model.ToEntity(userId, original);

            ImageUpload originalImageUpload = imageUploadRepository.FindOne(original.ImageId).FirstOrDefault();

            if (originalImageUpload == null)
            {
                ImageUpload imageUpload = new ImageUpload
                {
                    fileUrl = model.CompanyImageUpload,
                    Title = "image_" + model.Name,
                    Description = "image_Description_" + model.Name,
                    CreatedByUserId = entity.CreatedByUserId,
                    CreatedOn = entity.CreatedOn,
                    IsDeleted = false,
                    ModifiedByUserId = entity.ModifiedByUserId,
                    ModifiedOn = entity.ModifiedOn
                };
                using (UnitOfWork work = new UnitOfWork(imageUploadContext))
                {

                    imageUpload = imageUploadRepository.Add(imageUpload);
                    work.Complete();
                }
                entity.ImageId = imageUpload.Id;
            }

            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetCompanyByCompanyId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

