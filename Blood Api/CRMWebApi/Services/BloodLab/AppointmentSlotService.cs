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

    public class AppointmentSlotService : IAppointmentSlotService
    {
        public AppointmentSlotViewModel CreateAppointmentSlot(AppointmentSlotBindingModel model, int userId)
        {
            AppointmentSlot entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            AppointmentSlotViewModel model2 = new AppointmentSlotViewModel();
            AppointmentSlotRepository repository = new AppointmentSlotRepository(context);
            AppointmentSlot offer = repository.GetAll().
                FirstOrDefault(x => x.SlotTime.Contains(entity.SlotTime) && x.IsDeleted == false);
           
            using (UnitOfWork work = new UnitOfWork(context))
            {
                if (offer != null)
                {
                    throw new NashHandledExceptionNotFound("AppointmentSlot Name already Exist, Try another Name");
                }
                else
                {
                    entity = repository.Add(entity);
                    work.Complete();
                    return repository.FindOneMapped(entity.Id);
                }
            }
        }

        public bool DeleteAppointmentSlot(int AppointmentSlotId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentSlotRepository repository = new AppointmentSlotRepository(context);
            AppointmentSlot entity = repository.FindOne(AppointmentSlotId).FirstOrDefault<AppointmentSlot>();
          
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmentSlotId. AppointmentSlot Not Found.");
            }
          
           // if (entity.AppointmentSlotHeadId != null)
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
              //  throw new NashException("Head AppointmentSlot can't be deleted.");
        }

        public AppointmentSlotViewModel GetAppointmentSlotByAppointmentSlotId(int AppointmentSlotId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentSlotRepository repository = new AppointmentSlotRepository(context);
            if (repository.FindOne(AppointmentSlotId).FirstOrDefault<AppointmentSlot>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmentSlotId. AppointmentSlot Not Found.");
            }
            var result = repository.FindOneMapped(AppointmentSlotId);

            return result;
        }

        public NashPagedList<AppointmentSlotViewModel> GetAppointmentSlot(int rows, int pageNumber, int? BranchId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentSlotRepository repository = new AppointmentSlotRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber).ToViewModel();

            return result;
        }

        public AppointmentSlotViewModel UpdateAppointmentSlot(AppointmentSlotBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentSlotRepository repository = new AppointmentSlotRepository(context);
            int? AppointmentSlotId = model.AppointmentSlotId;
            AppointmentSlot original = repository.FindOne(AppointmentSlotId.HasValue ? AppointmentSlotId.GetValueOrDefault() : 0).FirstOrDefault<AppointmentSlot>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmentSlotId. AppointmentSlot Not Found.");
            }
            AppointmentSlot entity = model.ToEntity(userId, original);
            
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetAppointmentSlotByAppointmentSlotId(entity.Id);
        }

       

        public class AppointmentSlotChild
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

