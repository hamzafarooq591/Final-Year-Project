namespace NashWebApi.Repositories.BloodLab
{
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Linq;

    public interface IAppointmentOfferRepository : IRepository<AppointmentOffer>
    {
        IPagedList<AppointmentOffer> Filter(int rows, int pageNumber);
        IQueryable<AppointmentOffer> FindOne(int AppointmenTestId);
        AppointmentOfferViewModel FindOneMapped(int AppointmenTestId);
    }
}

