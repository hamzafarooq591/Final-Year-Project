namespace NashWebApi.Services.BloodLab
{
    using NashWebApi;
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Exceptions.NashHandledException;
    using NashWebApi.Extensions;
    using NashWebApi.Mappers.BloodLab;
    using NashWebApi.Repositories.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constant;
    using NashWebApi.Repositories;

    public class OfferService : IOfferService
    {
        public OfferViewModel CreateOffer(OfferBindingModel model, int userId)
        {
            Offer entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            OfferViewModel model2 = new OfferViewModel();
            OfferRepository repository = new OfferRepository(context);
            Offer offer = repository.GetAll().
                FirstOrDefault(x => x.Title.Contains(entity.Title));
           
            using (UnitOfWork work = new UnitOfWork(context))
            {
                if (offer != null)
                {
                    throw new NashHandledExceptionNotFound("Offer Name already Exist, Try another Name");
                }
                else
                {
                    entity = repository.Add(entity);
                    work.Complete();
                    return repository.FindOneMapped(entity.Id);
                }
            }
        }

        public bool DeleteOffer(int OfferId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OfferRepository repository = new OfferRepository(context);
            Offer entity = repository.FindOne(OfferId).FirstOrDefault<Offer>();
          
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OfferId. Offer Not Found.");
            }
          
           // if (entity.OfferHeadId != null)
           // {
                entity.IsDeleted = true;
                using (UnitOfWork work = new UnitOfWork(context))
                {
                    repository.Edit(entity);
                    work.Complete();
                }
                return true;
            //}
            //else
              //  throw new NashException("Head Offer can't be deleted.");
        }

        public OfferViewModel GetOfferByOfferId(int OfferId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OfferRepository repository = new OfferRepository(context);
            if (repository.FindOne(OfferId).FirstOrDefault<Offer>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OfferId. Offer Not Found.");
            }
            var result = repository.FindOneMapped(OfferId);

            return result;
        }

        public NashPagedList<OfferViewModel> GetOffer(int rows, int pageNumber, int? BranchId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OfferRepository repository = new OfferRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber).ToViewModel();

            return result;
        }

        public OfferViewModel UpdateOffer(OfferBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OfferRepository repository = new OfferRepository(context);
            int? OfferId = model.OfferId;
            Offer original = repository.FindOne(OfferId.HasValue ? OfferId.GetValueOrDefault() : 0).FirstOrDefault<Offer>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OfferId. Offer Not Found.");
            }
            Offer entity = model.ToEntity(userId, original);
            
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetOfferByOfferId(entity.Id);
        }

       

        public class OfferChild
        {
            public int testId {get;set;}
            public float totaldebit { get; set; }
            public float totalcredit { get; set; }
        }

        //get Profit & Loss()
        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

