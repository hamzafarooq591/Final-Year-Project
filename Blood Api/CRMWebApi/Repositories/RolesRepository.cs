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
    using System.Collections.Generic;
    
    public class RolesRepository : Repository<NashRole>, IRolesRepository, IRepository<NashRole>
    {
        public RolesRepository(NashWebApi.NashContext context) : base(context)
        {
        }


        public IPagedList<NashRole> Filter(int rows, int pageNumber , string SearchString ="")
        {
            var result = NashContext.NashRoles
               .Where(x =>  x.IsDeleted == false && (SearchString=="" ||x.Name.Contains(SearchString)));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<NashRole>(pageNumber, rows);
        }

        public NashRolesViewModel FindOneMapped(int nashUserId) =>
            this.FindOne(nashUserId).FirstOrDefault<NashRole>().ToViewModel();

        public IQueryable<NashRole> FindOne(int nashRoleId)
        {
            return NashContext.NashRoles
                .Where(x => x.Id == nashRoleId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

