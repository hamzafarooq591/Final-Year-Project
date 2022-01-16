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

    public class SiteSettingService : ISiteSettingService
    {
        public SiteSettingViewModel CreateSiteSetting(SiteSettingBindingModel model, int userId)
        {
            SiteSetting entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            SiteSettingViewModel model2 = new SiteSettingViewModel();
            SiteSettingRepository repository = new SiteSettingRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteSiteSetting(int SiteSettingId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SiteSettingRepository repository = new SiteSettingRepository(context);
            SiteSetting entity = repository.FindOne(SiteSettingId).FirstOrDefault<SiteSetting>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SiteSettingId. SiteSetting Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public SiteSettingViewModel GetSiteSettingBySiteSettingId(int SiteSettingId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SiteSettingRepository repository = new SiteSettingRepository(context);
            if (repository.FindOne(SiteSettingId).FirstOrDefault<SiteSetting>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SiteSettingId. SiteSetting Not Found.");
            }
            return repository.FindOneMapped(SiteSettingId);
        }

        public NashPagedList<SiteSettingViewModel> GetSiteSetting(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SiteSettingRepository repository = new SiteSettingRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public SiteSettingViewModel UpdateSiteSetting(SiteSettingBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SiteSettingRepository repository = new SiteSettingRepository(context);
            int? SiteSettingId = model.SiteSettingId;
            SiteSetting original = repository.FindOne(SiteSettingId.HasValue ? SiteSettingId.GetValueOrDefault() : 0).FirstOrDefault<SiteSetting>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SiteSettingId. SiteSetting Not Found.");
            }
            SiteSetting entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetSiteSettingBySiteSettingId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

