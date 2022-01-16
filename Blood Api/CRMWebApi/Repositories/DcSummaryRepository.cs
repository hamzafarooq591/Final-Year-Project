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
    
    public class DcSummaryRepository : Repository<DcSummary>, IDcSummaryRepository, IRepository<DcSummary>
    {
        public DcSummaryRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<DcSummary> Filter(int rows, int pageNumber)
        {
            var result = NashContext.DcSummaries
                .Include(x => x.Branch)
                .Include(x => x.Product)
                .Include(x => x.DcGroup)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<DcSummary>(pageNumber, rows);
        }
         
        public DcSummaryViewModel FindOneMapped(int DcSummaryId) =>
            this.FindOne(DcSummaryId).FirstOrDefault<DcSummary>().ToViewModel();

        public IQueryable<DcSummary> FindOne(int DcSummaryId)
        {
            return NashContext.DcSummaries
                .Include(x => x.Branch)
                .Include(x => x.Product)
                .Include(x => x.DcGroup)
                .Where(x => x.Id == DcSummaryId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

