namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ISmsConfigurationRepository : IRepository<SmsConfiguration>
    {
        IPagedList<SmsConfiguration> Filter(int rows, int pageNumber);
        IQueryable<SmsConfiguration> FindOne(int SmsConfigurationId);
        SmsConfigurationViewModel FindOneMapped(int SmsConfigurationId);
    }
}

