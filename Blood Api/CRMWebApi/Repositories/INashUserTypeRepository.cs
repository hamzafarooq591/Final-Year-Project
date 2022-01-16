namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INashUserTypeRepository : IRepository<NashUserType>
    {
        IPagedList<NashUserType> Filter(int rows, int pageNumber);
        IQueryable<NashUserType> FindOne(int NashUserTypeId);
        NashUserTypeViewModel FindOneMapped(int NashUserTypeId);
    }
}

