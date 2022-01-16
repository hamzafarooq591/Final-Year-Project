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

    public class NashUserRoleRepository : Repository<NashUserRole>, INashUserRoleRepository, IRepository<NashUserRole>
    {
        public NashUserRoleRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NashUserRole> Filter(int rows, int pageNumber)
        {
          
            return NashContext.NashUserRoles
                  .Include(x => x.NashUser)
               .Include(x => x.NashRole)
               .Where(x => x.IsDeleted == false)
               .OrderByDescending(x => x.Id)
               .ToPagedList<NashUserRole>(pageNumber, rows);
            
        }

        public IQueryable<NashUserRole> FindOne(int NashUserRoleId)
        {
            return this.NashContext.NashUserRoles
               .Include(x => x.NashUser)
               .Include(x => x.NashRole)
               .Where(x => x.Id == NashUserRoleId);
            
        }

        public NashUserRoleViewModel FindOneMapped(int NashUserRoleId) => 
            this.FindOne(NashUserRoleId).FirstOrDefault<NashUserRole>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

