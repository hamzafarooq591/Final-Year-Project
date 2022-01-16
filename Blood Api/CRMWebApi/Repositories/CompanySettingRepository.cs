namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections.Generic;
    
    public class CompanySettingRepository : Repository<CompanySetting>, ICompanySettingRepository, IRepository<CompanySetting>
    {
        public CompanySettingRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<CompanySetting> Filter(int rows, int pageNumber)
        {
            var result = NashContext.companySettings
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<CompanySetting>(pageNumber, rows);
        }
         
        public CompanySettingViewModel FindOneMapped(int CompanySettingId) =>
            this.FindOne(CompanySettingId).FirstOrDefault<CompanySetting>().ToViewModel();

        public IQueryable<CompanySetting> FindOne(int CompanySettingId)
        {
            return NashContext.companySettings
                .Where(x => x.Id == CompanySettingId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

