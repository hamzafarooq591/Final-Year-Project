namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class NashUserSessionRepository : Repository<NashUserSession>, INashUserSessionRepository, IRepository<NashUserSession>
    {
        public NashUserSessionRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NashUserSession> Filter(int rows, int pageNumber,int? nashUserId)
        {
            return NashContext.NashUserSessions
                .Include(x => x.NashUser)
                .Where(x => x.IsDeleted == false && x.NashUserId == nashUserId)
                .OrderByDescending(o => o.Id)
                .ToPagedList<NashUserSession>(pageNumber, rows);

        }

        public IQueryable<NashUserSession> FindOne(int NashUserSessionId)
        {

            return NashContext.NashUserSessions
                .Include(x => x.NashUser)
                .Where(x => x.Id == NashUserSessionId && x.IsDeleted == false);
        }

        public NashUserSessionViewModel FindOneMapped(int NashUserSessionId) => 
            this.FindOne(NashUserSessionId).FirstOrDefault<NashUserSession>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

