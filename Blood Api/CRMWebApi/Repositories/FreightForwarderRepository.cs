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
    
    public class FreightForwarderRepository : Repository<FreightForwarder>, IFreightForwarderRepository, IRepository<FreightForwarder>
    {
        public FreightForwarderRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<FreightForwarder> Filter(int rows, int pageNumber)
        {
            var result = NashContext.FreightForwarders
                .Include(x => x.Company)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<FreightForwarder>(pageNumber, rows);
        }
         
        public FreightForwarderViewModel FindOneMapped(int FreightForwarderId) =>
            this.FindOne(FreightForwarderId).FirstOrDefault<FreightForwarder>().ToViewModel();

        public IQueryable<FreightForwarder> FindOne(int FreightForwarderId)
        {
            return NashContext.FreightForwarders
                .Include(x => x.Company)
                .Where(x => x.Id == FreightForwarderId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

