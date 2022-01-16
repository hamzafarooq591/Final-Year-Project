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
    
    public class AdvanceSalaryRepository : Repository<AdvanceSalary>, IAdvanceSalaryRepository, IRepository<AdvanceSalary>
    {
        public AdvanceSalaryRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<AdvanceSalary> Filter(int rows, int pageNumber)
        {
            var result = NashContext.AdvanceSalaries
                .Include(x => x.BankAccount)
                .Include(x => x.Employee)
                .Include(x => x.PaymentType)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<AdvanceSalary>(pageNumber, rows);
        }
         
        public AdvanceSalaryViewModel FindOneMapped(int AdvanceSalaryId) =>
            this.FindOne(AdvanceSalaryId).FirstOrDefault<AdvanceSalary>().ToViewModel();

        public IQueryable<AdvanceSalary> FindOne(int AdvanceSalaryId)
        {
            return NashContext.AdvanceSalaries
                .Include(x => x.BankAccount)
                .Include(x => x.Employee)
                .Include(x => x.PaymentType)
                .Where(x => x.Id == AdvanceSalaryId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

