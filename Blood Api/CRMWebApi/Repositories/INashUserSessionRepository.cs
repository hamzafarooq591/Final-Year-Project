namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INashUserSessionRepository : IRepository<NashUserSession>
    {
        IPagedList<NashUserSession> Filter(int rows, int pageNumber, int? nashUserId);
        IQueryable<NashUserSession> FindOne(int NashUserSessionId);
        NashUserSessionViewModel FindOneMapped(int NashUserSessionId);
    }
}

