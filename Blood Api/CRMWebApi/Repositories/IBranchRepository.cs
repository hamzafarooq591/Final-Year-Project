namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IBranchRepository : IRepository<Branch>
    {
        IPagedList<Branch> Filter(int rows, int pageNumber, int? CompanyId);
        IQueryable<Branch> FindOne(int BranchId);
        BranchViewModel FindOneMapped(int BranchId);
    }
}

