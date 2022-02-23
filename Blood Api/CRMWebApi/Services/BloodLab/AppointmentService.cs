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
    using NashWebApi.Entities;
    using NashWebApi.Mappers;

    public class AppointmentService : IAppointmentService
    {
        //public ItemSaleMasterViewModel CreateItemSaleMaster(ItemSaleMasterBindingModel model, int userId)
        //{
        //    ItemSaleMaster entity = model.ToEntity(userId, null);

        //    NashWebApi.NashContext context = new NashWebApi.NashContext();
        //    int ItemSaleMasterId = 0;
        //    ItemSaleMasterViewModel model2 = new ItemSaleMasterViewModel();
        //    ItemSaleMasterRepository repository = new ItemSaleMasterRepository(context);
        //    using (UnitOfWork work = new UnitOfWork(context))
        //    {
        //        entity = repository.Add(entity);
        //        work.Complete();
        //        ItemSaleMasterId = entity.Id;

        //        model2 = repository.FindOneMapped(entity.Id);
        //    }
        //    foreach (var Item in model.itemSaleDetailList)
        //    {
        //        Item.ItemSaleMasterId = ItemSaleMasterId;

        //        NashWebApi.NashContext itemDetailContext = new NashContext();
        //        NashWebApi.NashContext itemContext = new NashContext();
        //        ItemRepository itemRepository = new ItemRepository(itemContext);
        //        ItemSaleDetailRepository itemSaleDetailRepository = new ItemSaleDetailRepository(itemDetailContext);
        //        ItemSaleDetail itemDetailEntity = Item.ToEntity(userId, null);

        //        using (UnitOfWork work = new UnitOfWork(itemDetailContext))
        //        {
        //            itemDetailEntity = itemSaleDetailRepository.Add(itemDetailEntity);
        //            //Item updating
        //            Item item = itemRepository.GetAll().FirstOrDefault(x => x.Id == itemDetailEntity.ItemId);
        //            item.Quantity = item.Quantity - itemDetailEntity.ItemQuantity;
        //            using (UnitOfWork iwork = new UnitOfWork(itemContext))
        //            {
        //                itemRepository.Edit(item);
        //                iwork.Complete();
        //            }
        //            //
        //            work.Complete();
        //        }

        //    }
        //    return model2;
        //}
        public AppointmentViewModel CreateAppointment(AppointmentBindingModel model, int userId)
        {
            Appointment entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            AppointmentViewModel model2 = new AppointmentViewModel();
            AppointmentRepository repository = new AppointmentRepository(context);
            int AppointmentId = 0;
           
            using (UnitOfWork work = new UnitOfWork(context))
            {
                    entity = repository.Add(entity);
                    work.Complete();
                    AppointmentId = entity.Id;    
            }
            NashWebApi.NashContext appointmentTestContext = new NashContext();
            
                       
            foreach (var Test in model.TestList)
            {
              
                var stest = appointmentTestContext.AppointmentTests.Where(w => w.Appointment.PatientId == model.PatientId && w.TestId==Test.TestId&& w.AppointmentId== AppointmentId).FirstOrDefault();
                if (stest!=null)
                {
                    //stest.AppointmentId = AppointmentId;                    
                }
                else
                {
                    AppointmentTest at = new AppointmentTest();
                    at.AppointmentId = AppointmentId;
                    at.TestId = Test.TestId;
                    at.CreatedByUserId = 1;
                    at.CreatedOn = DateTime.Now;
                    at.ModifiedOn = DateTime.Now;
                    at.ModifiedByUserId = 1;
                    appointmentTestContext.AppointmentTests.Add(at);
                    appointmentTestContext.SaveChanges();
                }
                var app = appointmentTestContext.Appointments.Where(w => w.Id == AppointmentId).FirstOrDefault();
                if (app == null)
                {
                    Appointment ap = new Appointment();
                    ap.PatientId = model.PatientId;
                    ap.AppointmentStatus = model.AppointmentStatus;
                    ap.Addres = model.Addres;
                    ap.AppointmentDateTime = model.AppointmentDateTime;
                    ap.City = model.City;
                    ap.IsBookingForMyself = model.IsBookingForMyself;
                    ap.AppointmentPatientName = model.AppointmentPatientName;
                    ap.PatientPhoneNumber = model.PatientPhoneNumber;
                    ap.PatientGender = model.PatientGender;
                    ap.PatientRelationship = model.PatientRelationship;
                    ap.Comment = model.Comment;
                    ap.TotalAmount = model.TotalAmount;
                    appointmentTestContext.Appointments.Add(ap);
                    appointmentTestContext.SaveChanges();
                }
                else
                {
                    app.AppointmentStatus =model.AppointmentStatus; 
                    app.TotalAmount = model.TotalAmount;
                }
                appointmentTestContext.SaveChanges();
            }
            if (model.OfferList!=null)
            {
                foreach (var Offer in model.OfferList)
                {
                    Offer.AppointmentId = AppointmentId;
                    if (Offer.OfferId == 0) continue;
                    NashWebApi.NashContext appointmentOfferContext = new NashContext();
                    if (Offer.OfferId == 0)
                    {
                        Offer.OfferId = appointmentOfferContext.AppointmentOffers.FirstOrDefault().Id;
                    }
                    AppointmentOfferRepository appointmentOfferRepository = new AppointmentOfferRepository(appointmentOfferContext);
                    AppointmentOffer appointmentOfferEntity = new AppointmentOffer();
                    appointmentOfferEntity.OfferId = (int)Offer.OfferId;
                    appointmentOfferEntity.AppointmentId = Offer.AppointmentId;
                    appointmentOfferEntity.CreatedByUserId = 1;
                    appointmentOfferEntity.ModifiedByUserId = 1;
                    appointmentOfferEntity.CreatedOn = DateTime.Now;
                    appointmentOfferEntity.ModifiedOn = DateTime.Now;

                    appointmentOfferContext.AppointmentOffers.Add(appointmentOfferEntity);
                    appointmentOfferContext.SaveChanges();
                }
            }
           

            return null;// repository.FindOneMapped(entity.Id);
        }

        public bool DeleteAppointment(int AppointmentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentRepository repository = new AppointmentRepository(context);
            Appointment entity = repository.FindOne(AppointmentId).FirstOrDefault<Appointment>();
          
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmentId. Appointment Not Found.");
            }
          
           // if (entity.AppointmentHeadId != null)
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
              //  throw new NashException("Head Appointment can't be deleted.");
        }

        public AppointmentViewModel GetAppointmentByAppointmentId(int AppointmentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentRepository repository = new AppointmentRepository(context);
            if (repository.FindOne(AppointmentId).FirstOrDefault<Appointment>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmentId. Appointment Not Found.");
            }
            var result = repository.FindOneMapped(AppointmentId);

            AppointmentTestRepository appointmentTestRepository = new AppointmentTestRepository(context);
            var appointmentTestList = appointmentTestRepository.FindAllByAppointmentId(AppointmentId).ToList();

            var testList = new List<TestViewModel>();

            foreach(var appointmentTest in appointmentTestList)
            {
                testList.Add(appointmentTest.Test.ToViewModel());
            }

            AppointmentOfferRepository appointmentOfferRepository = new AppointmentOfferRepository(context);
            var appointmentOfferList = appointmentOfferRepository.FindAllByAppointmentId(AppointmentId).ToList();

            var offerList = new List<OfferViewModel>();

            foreach (var appointmentOffer in appointmentOfferList)
            {
                offerList.Add(appointmentOffer.Offer.ToViewModel());
            }

            result.TestList = testList;
            result.OfferList = offerList;

            return result;
        }
        public List<AppointmentViewModel> GetAppointmentByPatientId(int? PatientId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentRepository repository = new AppointmentRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.GetAll()
                .Where<Appointment>(x => x.PatientId == PatientId).ToList<Appointment>()
                .ToViewModel();

            foreach(var appointment in result)
            {
                

                AppointmentTestResultRepository appointmentTestResultRepository = new AppointmentTestResultRepository(context);

                var numberOfResults = appointmentTestResultRepository
                    .FindAllUnMappedByAppointmentId(appointment.AppointmentId.Value).Count();

                appointment.NumberOfResults = numberOfResults;
                appointment.ResultPending = numberOfResults == 0 ? true : false;
            }


            return result;
        }
        public NashPagedList<AppointmentViewModel> GetAppointment(int rows, int pageNumber, int? BranchId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentRepository repository = new AppointmentRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber).ToViewModel();

            return result;
        }

        public AppointmentViewModel UpdateAppointment(AppointmentBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentRepository repository = new AppointmentRepository(context);
            int? AppointmentId = model.AppointmentId;
            Appointment original = repository.FindOne(AppointmentId.HasValue ? AppointmentId.GetValueOrDefault() : 0).FirstOrDefault<Appointment>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmentId. Appointment Not Found.");
            }
            Appointment entity = model.ToEntity(userId, original);
            
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }

            NashWebApi.NashContext appointmentTestDeletContext = new NashContext();
            AppointmentTestRepository appointmentTestDeleteRepository = new AppointmentTestRepository(appointmentTestDeletContext);
            var appointmentTestList = appointmentTestDeleteRepository.GetAll().Where<AppointmentTest>(x => x.AppointmentId == AppointmentId.Value);
            
            foreach(var appointmentTest in appointmentTestList)
            {
                
                using (UnitOfWork work = new UnitOfWork(context))
                {
                    appointmentTestDeleteRepository.Delete(appointmentTest);
                    work.Complete();
                }
            }

            NashWebApi.NashContext appointmentOfferDeletContext = new NashContext();
            AppointmentOfferRepository appointmentOfferDeleteRepository = new AppointmentOfferRepository(appointmentOfferDeletContext);
            var appointmentOfferList = appointmentOfferDeleteRepository.GetAll().Where<AppointmentOffer>(x => x.AppointmentId == AppointmentId.Value);

            foreach (var appointmentOffer in appointmentOfferList)
            {
                using (UnitOfWork work = new UnitOfWork(context))
                {
                    appointmentOfferDeleteRepository.Delete(appointmentOffer);
                    work.Complete();
                }
            }


            foreach (var Test in model.TestList)
            {
                Test.AppointmentId = AppointmentId.Value;

                NashWebApi.NashContext appointmentTestContext = new NashContext();
                AppointmentTestRepository appointmentTestRepository = new AppointmentTestRepository(appointmentTestContext);
                AppointmentTest appointmentTestEntity = Test.ToEntity(userId, null);

                using (UnitOfWork work = new UnitOfWork(appointmentTestContext))
                {
                    appointmentTestEntity = appointmentTestRepository.Add(appointmentTestEntity);
                    work.Complete();
                }
            }

            foreach (var Offer in model.OfferList)
            {
                Offer.AppointmentId = AppointmentId.Value;

                NashWebApi.NashContext appointmentOfferContext = new NashContext();
                AppointmentOfferRepository appointmentOfferRepository = new AppointmentOfferRepository(appointmentOfferContext);
                AppointmentOffer appointmentOfferEntity = Offer.ToEntity(userId, null);

                using (UnitOfWork work = new UnitOfWork(appointmentOfferContext))
                {
                    appointmentOfferEntity = appointmentOfferRepository.Add(appointmentOfferEntity);
                    work.Complete();
                }
            }

            return null; // this.GetAppointmentByAppointmentId(entity.Id);
        }

       

        

        //get Profit & Loss()
        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

