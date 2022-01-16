namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IClearingAgentRepository : IRepository<ClearingAgent>
    {
        IPagedList<ClearingAgent> Filter(int rows, int pageNumber);
        IQueryable<ClearingAgent> FindOne(int ClearingAgentId);
        ClearingAgentViewModel FindOneMapped(int ClearingAgentId);
    }
}

