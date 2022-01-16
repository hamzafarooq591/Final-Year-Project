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

    public class NashUserTypeRepository : Repository<NashUserType>, INashUserTypeRepository, IRepository<NashUserType>
    {
        public NashUserTypeRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NashUserType> Filter(int rows, int pageNumber)
        {

            return NashContext.NashUserTypes
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<NashUserType>(pageNumber, rows);
        }

        public IQueryable<NashUserType> FindOne(int NashUserTypeId)
        {

            return NashContext.NashUserTypes
                .Where(x => x.IsDeleted == false && x.Id == NashUserTypeId);
        }

        public NashUserTypeViewModel FindOneMapped(int NashUserTypeId) =>
            this.FindOne(NashUserTypeId).FirstOrDefault<NashUserType>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

