namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class PayslipRepository : Repository<Payslip>, IPayslipRepository, IRepository<Payslip>
    {
        public PayslipRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Payslip> Filter(int rows, int pageNumber)
        {
            var result = NashContext.Payslips
                .Include(x => x.Employee)
                .Include(x => x.Employee.Branch)
                .Include(x => x.Employee.Designation)
                .Include(x => x.Approval)
               .Where(x => x.IsDeleted == false );
            return result.OrderByDescending(o => o.Id)
                 .ToPagedList<Payslip>(pageNumber, rows);

        }

        public PayslipViewModel FindOneMapped(int PayslipId) =>
            this.FindOne(PayslipId).FirstOrDefault<Payslip>().ToViewModel();

        public IQueryable<Payslip> FindOne(int PayslipId)
        {
            return NashContext.Payslips
                         .Include(x => x.Employee)
                         .Include(x => x.Employee.Branch)
                         .Include(x => x.Employee.Designation)
                         .Include(x => x.Approval)
                          .Where(x => x.Id == PayslipId && x.IsDeleted == false);
            ;
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

