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

    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository, IRepository<Currency>
    {
        public CurrencyRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<Currency> Filter(int rows, int pageNumber)
        {

            return NashContext.Currencys
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<Currency>(pageNumber, rows);
        }

        public IQueryable<Currency> FindOne(int CurrencyId)
        {

            return NashContext.Currencys
                .Where(x => x.IsDeleted == false && x.Id == CurrencyId);
        }

        public CurrencyViewModel FindOneMapped(int CurrencyId) =>
            this.FindOne(CurrencyId).FirstOrDefault<Currency>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

