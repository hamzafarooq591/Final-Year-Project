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
    
    public class AppointmentOfferRepository : Repository<AppointmentOffer>, IAppointmentOfferRepository, IRepository<AppointmentOffer>
    {
        public AppointmentOfferRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<AppointmentOffer> Filter(int rows, int pageNumber)
        {
            var result = NashContext.AppointmentOffers
               .Where(x =>  x.IsDeleted == false );
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<AppointmentOffer>(pageNumber, rows);
        }
        //ParentAppointmentOfferId List
        
        public AppointmentOfferViewModel FindOneMapped(int AppointmentOfferId) =>
            this.FindOne(AppointmentOfferId).FirstOrDefault<AppointmentOffer>().ToViewModel();

        public IQueryable<AppointmentOffer> FindOne(int AppointmentOfferId)
        {
            return NashContext.AppointmentOffers
                .Include(x => x.Offer)
                .Where(x => x.Id == AppointmentOfferId && x.IsDeleted == false);
        }
        public List<AppointmentOffer> FindAllByAppointmentId(int AppointmentId)
        {
            return NashContext.AppointmentOffers
                .Include(x => x.Offer)
                .Where(x => x.AppointmentId == AppointmentId && x.IsDeleted == false).ToList<AppointmentOffer>();
        }



        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

