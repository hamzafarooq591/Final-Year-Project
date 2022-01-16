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
    
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository, IRepository<Employee>
    {
        public EmployeeRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Employee> Filter(int rows, int pageNumber , string SearchString ="")
        {
            var result = NashContext.Employees
                .Include(x => x.Designation)
                .Include(x => x.Branch)
               .Where(x => x.IsDeleted == false && (SearchString == "" || x.EmployeeFName.Contains(SearchString) || x.EmployeeLName.Contains(SearchString)));
               return result.OrderByDescending(o => o.Id)
                    .ToPagedList<Employee>(pageNumber, rows);
            
        }
         
        public EmployeeViewModel FindOneMapped(int EmployeeId) =>
            this.FindOne(EmployeeId).FirstOrDefault<Employee>().ToViewModel();

        public IQueryable<Employee> FindOne(int EmployeeId)
        {
            return  NashContext.Employees
                         .Include(x => x.Designation)
                         .Include(x => x.Branch)
                          .Where(x => x.Id == EmployeeId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

