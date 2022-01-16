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
    
    public class BranchRepository : Repository<Branch>, IBranchRepository, IRepository<Branch>
    {
        public BranchRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Branch> Filter(int rows, int pageNumber , int? CompanyId = null)
        {
            var result = NashContext.Branches
                .Include(x => x.Company)
               .Where(x =>  x.IsDeleted == false 
               &&
               (CompanyId == null || x.Company.Id == CompanyId));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Branch>(pageNumber, rows);
        }
       
        public BranchViewModel FindOneMapped(int BranchId) =>
            this.FindOne(BranchId).FirstOrDefault<Branch>().ToViewModel();

        public IQueryable<Branch> FindOne(int BranchId)
        {
            return NashContext.Branches
                .Include(x => x.Company)
                .Where(x => x.Id == BranchId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

