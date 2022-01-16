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
    
    public class MoneyChangerRepository : Repository<MoneyChanger>, IMoneyChangerRepository, IRepository<MoneyChanger>
    {
        public MoneyChangerRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<MoneyChanger> Filter(int rows, int pageNumber)
        {
            var result = NashContext.MoneyChangers
                .Include(x => x.Account)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<MoneyChanger>(pageNumber, rows);
        }
         
        public MoneyChangerViewModel FindOneMapped(int MoneyChangerId) =>
            this.FindOne(MoneyChangerId).FirstOrDefault<MoneyChanger>().ToViewModel();

        public IQueryable<MoneyChanger> FindOne(int MoneyChangerId)
        {
            return NashContext.MoneyChangers
                .Include(x => x.Account)
                .Where(x => x.Id == MoneyChangerId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

