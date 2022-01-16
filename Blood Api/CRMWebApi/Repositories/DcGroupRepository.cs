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

    public class DcGroupRepository : Repository<DcGroup>, IDcGroupRepository, IRepository<DcGroup>
    {
        public DcGroupRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<DcGroup> Filter(int rows, int pageNumber)
        {

            return NashContext.DcGroups
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<DcGroup>(pageNumber, rows);
        }

        public IQueryable<DcGroup> FindOne(int DcGroupId)
        {

            return NashContext.DcGroups
                .Where(x => x.IsDeleted == false && x.Id == DcGroupId);
        }

        public DcGroupViewModel FindOneMapped(int DcGroupId) =>
            this.FindOne(DcGroupId).FirstOrDefault<DcGroup>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

