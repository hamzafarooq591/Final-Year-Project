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
    
    public class ClearingAgentRepository : Repository<ClearingAgent>, IClearingAgentRepository, IRepository<ClearingAgent>
    {
        public ClearingAgentRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<ClearingAgent> Filter(int rows, int pageNumber)
        {
            var result = NashContext.ClearingAgents
                .Include(x => x.Company)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<ClearingAgent>(pageNumber, rows);
        }
         
        public ClearingAgentViewModel FindOneMapped(int ClearingAgentId) =>
            this.FindOne(ClearingAgentId).FirstOrDefault<ClearingAgent>().ToViewModel();

        public IQueryable<ClearingAgent> FindOne(int ClearingAgentId)
        {
            return NashContext.ClearingAgents
                .Include(x => x.Company)
                .Where(x => x.Id == ClearingAgentId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

