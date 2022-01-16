namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ICompanySettingRepository : IRepository<CompanySetting>
    {
        IPagedList<CompanySetting> Filter(int rows, int pageNumber);
        IQueryable<CompanySetting> FindOne(int CompanySettingId);
        CompanySettingViewModel FindOneMapped(int CompanySettingId);
    }
}

