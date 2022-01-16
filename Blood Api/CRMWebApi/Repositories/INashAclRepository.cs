namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INashAclRepository : IRepository<NashAcl>
    {
        IPagedList<NashAcl> Filter(int rows, int pageNumber);
        IQueryable<NashAcl> FindOne(int NashAclId);
        NashAclViewModel FindOneMapped(int NashAclId);
        IQueryable<NashAcl> FindOneByNashRoleId(int NashRoleId);
    }
}

