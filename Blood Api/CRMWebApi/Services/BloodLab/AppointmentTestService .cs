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

    public class AppointmentTestService : IAppointmentTestService
    {
        public AppointmentTestViewModel CreateAppointmentTest(AppointmentTestBindingModel model, int userId)
        {
            AppointmentTest entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            AppointmentTestViewModel model2 = new AppointmentTestViewModel();
            AppointmentTestRepository repository = new AppointmentTestRepository(context);
           
            using (UnitOfWork work = new UnitOfWork(context))
            {
                //if (appointmentTest != null)
                //{
                //    throw new NashHandledExceptionNotFound("AppointmenTest Name already Exist, Try another Name");
                //}
                //else
                //{
                    entity = repository.Add(entity);
                    work.Complete();
                    return repository.FindOneMapped(entity.Id);
                //}
            }
        }

        public List<AppointmentTestViewModel> GetAppointmentTestByAppointmentId(int? AppointmentId = null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentTestRepository repository = new AppointmentTestRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.GetAll()
                .Where<AppointmentTest>(x => x.AppointmentId == AppointmentId).ToList<AppointmentTest>()
                .ToViewModel();


            return result;
        }

        public bool DeleteAppointmentTest(int AppointmentTestId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentTestRepository repository = new AppointmentTestRepository(context);
            AppointmentTest entity = repository.FindOne(AppointmentTestId).FirstOrDefault<AppointmentTest>();
          
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmenTestId. AppointmenTest Not Found.");
            }
          
           // if (entity.AppointmenTestHeadId != null)
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
              //  throw new NashException("Head AppointmenTest can't be deleted.");
        }

        public AppointmentTestViewModel GetAppointmentTestByAppointmentTestId(int AppointmenTestId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentTestRepository repository = new AppointmentTestRepository(context);
            if (repository.FindOne(AppointmenTestId).FirstOrDefault<AppointmentTest>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmenTestId. AppointmenTest Not Found.");
            }
            var result = repository.FindOneMapped(AppointmenTestId);

            return result;
        }

        public NashPagedList<AppointmentTestViewModel> GetAppointmentTest(int rows, int pageNumber, int? BranchId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentTestRepository repository = new AppointmentTestRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber).ToViewModel();

            return result;
        }

        public AppointmentTestViewModel UpdateAppointmentTest(AppointmentTestBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentTestRepository repository = new AppointmentTestRepository(context);
            int? AppointmenTestId = model.AppointmentTestId;
            AppointmentTest original = repository.FindOne(AppointmenTestId.HasValue ? AppointmenTestId.GetValueOrDefault() : 0).FirstOrDefault<AppointmentTest>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmenTestId. AppointmenTest Not Found.");
            }
            AppointmentTest entity = model.ToEntity(userId, original);
            
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetAppointmentTestByAppointmentTestId(entity.Id);
        }

       

       

        //get Profit & Loss()
        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

