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
    
    public class EmployeeLoanRepository : Repository<EmployeeLoan>, IEmployeeLoanRepository, IRepository<EmployeeLoan>
    {
        public EmployeeLoanRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<EmployeeLoan> Filter(int rows, int pageNumber )
        {
            var result = NashContext.EmployeeLoanes
                .Include(x=> x.Employee)
                .Include(x => x.Approval)
               .Where(x => x.IsDeleted == false );
               return result.OrderByDescending(o => o.Id)
                    .ToPagedList<EmployeeLoan>(pageNumber, rows);
            
        }
         
        public EmployeeLoanViewModel FindOneMapped(int EmployeeLoanId) =>
            this.FindOne(EmployeeLoanId).FirstOrDefault<EmployeeLoan>().ToViewModel();

        public IQueryable<EmployeeLoan> FindOne(int EmployeeLoanId)
        {
            return  NashContext.EmployeeLoanes
                         .Include(x => x.Employee)
                         .Include(x => x.Approval)
                          .Where(x => x.Id == EmployeeLoanId && x.IsDeleted == false);
             ;
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

