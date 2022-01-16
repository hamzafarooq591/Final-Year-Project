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
    
    public class CompanyRepository : Repository<NashCompany>, ICompanyRepository, IRepository<NashCompany>
    {
        public CompanyRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<NashCompany> Filter(int rows, int pageNumber , string SearchString ="")
        {
            var result = NashContext.NashCompanies
                .Include(x => x.CompanyImage)
               .Where(x =>  x.IsDeleted == false && (SearchString=="" ||x.Name.Contains(SearchString)));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<NashCompany>(pageNumber, rows);
        }
         
        public CompanyViewModel FindOneMapped(int companyId) =>
            this.FindOne(companyId).FirstOrDefault<NashCompany>().ToViewModel();

        public IQueryable<NashCompany> FindOne(int companyId)
        {
            return NashContext.NashCompanies
                .Include(x => x.CompanyImage)
                .Where(x => x.Id == companyId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

