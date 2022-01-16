namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ICourierCompanyRepository : IRepository<CourierCompany>
    {
        IPagedList<CourierCompany> Filter(int rows, int pageNumber);
        IQueryable<CourierCompany> FindOne(int CourierCompanyId);
        CourierCompanyViewModel FindOneMapped(int CourierCompanyId);
    }
}

