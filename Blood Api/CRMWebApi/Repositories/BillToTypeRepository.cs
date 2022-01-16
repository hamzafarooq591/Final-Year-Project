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

    public class BillToTypeRepository : Repository<BillToType>, IBillToTypeRepository, IRepository<BillToType>
    {
        public BillToTypeRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<BillToType> Filter(int rows, int pageNumber)
        {

            return NashContext.BillToTypes
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<BillToType>(pageNumber, rows);
        }

        public IQueryable<BillToType> FindOne(int BillToTypeId)
        {

            return NashContext.BillToTypes
                .Where(x => x.IsDeleted == false && x.Id == BillToTypeId);
        }

        public BillToTypeViewModel FindOneMapped(int BillToTypeId) =>
            this.FindOne(BillToTypeId).FirstOrDefault<BillToType>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

