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

    public class NashAclRepository : Repository<NashAcl>, INashAclRepository, IRepository<NashAcl>
    {
        public NashAclRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NashAcl> Filter(int rows, int pageNumber)
        {
            return NashContext.NashAcls
               .Include(x => x.Role)
               .Include(x => x.Page)
               .Where(x => x.IsDeleted == false)
               .OrderByDescending(x => x.Id)
               .ToPagedList<NashAcl>(pageNumber, rows);
        }

        public IQueryable<NashAcl> FindOne(int NashAclId)
        {
            return NashContext.NashAcls
                .Include(x => x.Role)
                .Include(x => x.Page)
                .Where(x => x.Id == NashAclId && x.IsDeleted == false);
        }

        public IQueryable<NashAcl> FindOneByNashRoleId(int NashRoleId)
        {
            return NashContext.NashAcls
                .Include(x => x.Role)
                .Include(x => x.Page)
                .Where(x => x.RoleId == NashRoleId && x.IsDeleted == false);
        }

        public NashAclViewModel FindOneMapped(int NashAclId) => 
            this.FindOne(NashAclId).FirstOrDefault<NashAcl>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

