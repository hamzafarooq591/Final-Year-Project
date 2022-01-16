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
    
    public class BankRepository : Repository<Bank>, IBankRepository, IRepository<Bank>
    {
        public BankRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Bank> Filter(int rows, int pageNumber , string SearchString ="")
        {
            var result = NashContext.Banks
               .Where(x =>  x.IsDeleted == false && (SearchString=="" ||x.BankName.Contains(SearchString)));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Bank>(pageNumber, rows);
        }
         
        public BankViewModel FindOneMapped(int BankId) =>
            this.FindOne(BankId).FirstOrDefault<Bank>().ToViewModel();

        public IQueryable<Bank> FindOne(int BankId)
        {
            return NashContext.Banks
                .Where(x => x.Id == BankId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

