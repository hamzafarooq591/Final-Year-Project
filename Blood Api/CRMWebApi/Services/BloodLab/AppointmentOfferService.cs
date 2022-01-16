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

    public class AppointmentOfferService : IAppointmentOfferService
    {
        public AppointmentOfferViewModel CreateAppointmentOffer(AppointmentOfferBindingModel model, int userId)
        {
            AppointmentOffer entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            AppointmentOfferViewModel model2 = new AppointmentOfferViewModel();
            AppointmentOfferRepository repository = new AppointmentOfferRepository(context);
        
           
            using (UnitOfWork work = new UnitOfWork(context))
            {
                //if (offer != null)
                //{
                //    throw new NashHandledExceptionNotFound("AppointmentOffer Name already Exist, Try another Name");
                //}
                //else
                //{
                    entity = repository.Add(entity);
                    work.Complete();
                    return repository.FindOneMapped(entity.Id);
               // }
            }
        }

        public bool DeleteAppointmentOffer(int AppointmentOfferId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentOfferRepository repository = new AppointmentOfferRepository(context);
            AppointmentOffer entity = repository.FindOne(AppointmentOfferId).FirstOrDefault<AppointmentOffer>();
          
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmentOfferId. AppointmentOffer Not Found.");
            }
          
           // if (entity.AppointmentOfferHeadId != null)
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
              //  throw new NashException("Head AppointmentOffer can't be deleted.");
        }

        public AppointmentOfferViewModel GetAppointmentOfferByAppointmentOfferId(int AppointmentOfferId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentOfferRepository repository = new AppointmentOfferRepository(context);
            if (repository.FindOne(AppointmentOfferId).FirstOrDefault<AppointmentOffer>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmentOfferId. AppointmentOffer Not Found.");
            }
            var result = repository.FindOneMapped(AppointmentOfferId);

            return result;
        }

        public NashPagedList<AppointmentOfferViewModel> GetAppointmentOffer(int rows, int pageNumber, int? BranchId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentOfferRepository repository = new AppointmentOfferRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber).ToViewModel();

            return result;
        }

        public AppointmentOfferViewModel UpdateAppointmentOffer(AppointmentOfferBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentOfferRepository repository = new AppointmentOfferRepository(context);
            int? AppointmentOfferId = model.AppointmentOfferId;
            AppointmentOffer original = repository.FindOne(AppointmentOfferId.HasValue ? AppointmentOfferId.GetValueOrDefault() : 0).FirstOrDefault<AppointmentOffer>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmentOfferId. AppointmentOffer Not Found.");
            }
            AppointmentOffer entity = model.ToEntity(userId, original);
            
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetAppointmentOfferByAppointmentOfferId(entity.Id);
        }

       

        public class AppointmentOfferChild
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

