namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IDesignationRepository : IRepository<Designation>
    {
        IPagedList<Designation> Filter(int rows, int pageNumber);
        IQueryable<Designation> FindOne(int DesignationId);
        DesignationViewModel FindOneMapped(int DesignationId);
    }
}

