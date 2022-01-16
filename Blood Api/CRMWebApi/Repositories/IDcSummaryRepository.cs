namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IDcSummaryRepository : IRepository<DcSummary>
    {
        IPagedList<DcSummary> Filter(int rows, int pageNumber);
        IQueryable<DcSummary> FindOne(int DcSummaryId);
        DcSummaryViewModel FindOneMapped(int DcSummaryId);
    }
}

