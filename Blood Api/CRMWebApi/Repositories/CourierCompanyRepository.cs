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

    public class CourierCompanyRepository : Repository<CourierCompany>, ICourierCompanyRepository, IRepository<CourierCompany>
    {
        public CourierCompanyRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<CourierCompany> Filter(int rows, int pageNumber)
        {

            return NashContext.CourierCompanies
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<CourierCompany>(pageNumber, rows);
        }

        public IQueryable<CourierCompany> FindOne(int CourierCompanyId)
        {

            return NashContext.CourierCompanies
                .Where(x => x.IsDeleted == false && x.Id == CourierCompanyId);
        }

        public CourierCompanyViewModel FindOneMapped(int CourierCompanyId) =>
            this.FindOne(CourierCompanyId).FirstOrDefault<CourierCompany>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

