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
    
    public class SmsConfigurationRepository : Repository<SmsConfiguration>, ISmsConfigurationRepository, IRepository<SmsConfiguration>
    {
        public SmsConfigurationRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<SmsConfiguration> Filter(int rows, int pageNumber)
        {
            var result = NashContext.SmsConfigurations
                .Include(x => x.SmsType)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<SmsConfiguration>(pageNumber, rows);
        }
         
        public SmsConfigurationViewModel FindOneMapped(int SmsConfigurationId) =>
            this.FindOne(SmsConfigurationId).FirstOrDefault<SmsConfiguration>().ToViewModel();

        public IQueryable<SmsConfiguration> FindOne(int SmsConfigurationId)
        {
            return NashContext.SmsConfigurations
                .Include(x => x.SmsType)
                .Where(x => x.Id == SmsConfigurationId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

