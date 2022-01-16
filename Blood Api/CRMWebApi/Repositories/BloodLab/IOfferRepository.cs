namespace NashWebApi.Repositories.BloodLab
{
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Linq;

    public interface IOfferRepository : IRepository<Offer>
    {
        IPagedList<Offer> Filter(int rows, int pageNumber);
        IQueryable<Offer> FindOne(int OfferId);
        OfferViewModel FindOneMapped(int OfferId);
    }
}

