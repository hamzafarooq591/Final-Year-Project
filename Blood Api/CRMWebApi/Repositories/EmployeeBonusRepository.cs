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
    
    public class EmployeeBonusRepository : Repository<EmployeeBonus>, IEmployeeBonusRepository, IRepository<EmployeeBonus>
    {
        public EmployeeBonusRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<EmployeeBonus> Filter(int rows, int pageNumber , string SearchString ="")
        {
            var result = NashContext.EmployeeBonuses
                .Include(x=> x.Employee)
               .Where(x => x.IsDeleted == false && (SearchString == "" || x.BonusOccasion.Contains(SearchString)));
               return result.OrderByDescending(o => o.Id)
                    .ToPagedList<EmployeeBonus>(pageNumber, rows);
            
        }
         
        public EmployeeBonusViewModel FindOneMapped(int EmployeeBonusId) =>
            this.FindOne(EmployeeBonusId).FirstOrDefault<EmployeeBonus>().ToViewModel();

        public IQueryable<EmployeeBonus> FindOne(int EmployeeBonusId)
        {
            return  NashContext.EmployeeBonuses
                         .Include(x => x.Employee)
                          .Where(x => x.Id == EmployeeBonusId && x.IsDeleted == false);
             ;
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

