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

    public class PayToTypeRepository : Repository<PayToType>, IPayToTypeRepository, IRepository<PayToType>
    {
        public PayToTypeRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<PayToType> Filter(int rows, int pageNumber)
        {

            return NashContext.PayToTypes
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<PayToType>(pageNumber, rows);
        }

        public IQueryable<PayToType> FindOne(int PayToTypeId)
        {

            return NashContext.PayToTypes
                .Where(x => x.IsDeleted == false && x.Id == PayToTypeId);
        }

        public PayToTypeViewModel FindOneMapped(int PayToTypeId) =>
            this.FindOne(PayToTypeId).FirstOrDefault<PayToType>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

