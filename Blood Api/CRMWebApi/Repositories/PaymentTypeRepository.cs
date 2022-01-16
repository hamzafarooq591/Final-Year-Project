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

    public class PaymentTypeRepository : Repository<PaymentType>, IPaymentTypeRepository, IRepository<PaymentType>
    {
        public PaymentTypeRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<PaymentType> Filter(int rows, int pageNumber)
        {

            return NashContext.PaymentTypes
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<PaymentType>(pageNumber, rows);
        }

        public IQueryable<PaymentType> FindOne(int PaymentTypeId)
        {

            return NashContext.PaymentTypes
                .Where(x => x.IsDeleted == false && x.Id == PaymentTypeId);
        }

        public PaymentTypeViewModel FindOneMapped(int PaymentTypeId) =>
            this.FindOne(PaymentTypeId).FirstOrDefault<PaymentType>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

