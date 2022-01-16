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

    //public class NashRoleRepository : Repository<NashPage>, INashPageRepository, IRepository<NashPage>
    //{
    //}

        public class NashPageRepository : Repository<NashPage>, INashPageRepository, IRepository<NashPage>
    {
        public NashPageRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NashPage> Filter(int rows, int pageNumber)
        {
           
            return NashContext.NashPages
                .Include(x => x.ParentPage)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .ToPagedList<NashPage>(pageNumber, rows);
        }

        public IQueryable<NashPage> FindOne(int NashPageId)
        {
            return NashContext.NashPages
                .Include(x => x.ParentPage)
                .Where(x => x.IsDeleted == false && x.Id == NashPageId);
        }

        public NashPageViewModel FindOneMapped(int NashPageId) => 
            this.FindOne(NashPageId).FirstOrDefault<NashPage>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

