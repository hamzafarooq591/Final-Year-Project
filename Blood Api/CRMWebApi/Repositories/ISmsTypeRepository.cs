namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ISmsTypeRepository : IRepository<SmsType>
    {
        IPagedList<SmsType> Filter(int rows, int pageNumber);
        IQueryable<SmsType> FindOne(int SmsTypeId);
        SmsTypeViewModel FindOneMapped(int SmsTypeId);
    }
}

