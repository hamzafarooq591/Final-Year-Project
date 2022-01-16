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

    public class DesignationRepository : Repository<Designation>, IDesignationRepository, IRepository<Designation>
    {
        public DesignationRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<Designation> Filter(int rows, int pageNumber)
        {

            return NashContext.Designations
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<Designation>(pageNumber, rows);
        }

        public IQueryable<Designation> FindOne(int DesignationId)
        {

            return NashContext.Designations
                .Where(x => x.IsDeleted == false && x.Id == DesignationId);
        }

        public DesignationViewModel FindOneMapped(int DesignationId) =>
            this.FindOne(DesignationId).FirstOrDefault<Designation>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

