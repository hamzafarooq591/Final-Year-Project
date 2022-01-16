namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IApprovalRepository : IRepository<Approval>
    {
        IPagedList<Approval> Filter(int rows, int pageNumber);
        IQueryable<Approval> FindOne(int ApprovalId);
        ApprovalViewModel FindOneMapped(int ApprovalId);
    }
}

