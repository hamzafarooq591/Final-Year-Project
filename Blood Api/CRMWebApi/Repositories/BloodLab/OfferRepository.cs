namespace NashWebApi.Repositories.BloodLab
{
    using NashWebApi;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Mappers.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections.Generic;
    
    public class OfferRepository : Repository<Offer>, IOfferRepository, IRepository<Offer>
    {
        public OfferRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Offer> Filter(int rows, int pageNumber)
        {
            var result = NashContext.Offers
               .Where(x =>  x.IsDeleted == false );
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Offer>(pageNumber, rows);
        }
        //ParentOfferId List
        
        public OfferViewModel FindOneMapped(int OfferId) =>
            this.FindOne(OfferId).FirstOrDefault<Offer>().ToViewModel();

        public IQueryable<Offer> FindOne(int OfferId)
        {
            return NashContext.Offers
                .Where(x => x.Id == OfferId && x.IsDeleted == false);
        }

      

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

