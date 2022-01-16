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

    public class SmsTypeRepository : Repository<SmsType>, ISmsTypeRepository, IRepository<SmsType>
    {
        public SmsTypeRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<SmsType> Filter(int rows, int pageNumber)
        {

            return NashContext.SmsTypes
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<SmsType>(pageNumber, rows);
        }

        public IQueryable<SmsType> FindOne(int SmsTypeId)
        {

            return NashContext.SmsTypes
                .Where(x => x.IsDeleted == false && x.Id == SmsTypeId);
        }

        public SmsTypeViewModel FindOneMapped(int SmsTypeId) =>
            this.FindOne(SmsTypeId).FirstOrDefault<SmsType>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

