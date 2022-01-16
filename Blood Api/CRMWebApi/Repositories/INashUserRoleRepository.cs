namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INashUserRoleRepository : IRepository<NashUserRole>
    {
        IPagedList<NashUserRole> Filter(int rows, int pageNumber);
        IQueryable<NashUserRole> FindOne(int NashUserRoleId);
        NashUserRoleViewModel FindOneMapped(int NashUserRoleId);
    }
}

