namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IDcGroupRepository : IRepository<DcGroup>
    {
        IPagedList<DcGroup> Filter(int rows, int pageNumber);
        IQueryable<DcGroup> FindOne(int DcGroupId);
        DcGroupViewModel FindOneMapped(int DcGroupId);
    }
}

