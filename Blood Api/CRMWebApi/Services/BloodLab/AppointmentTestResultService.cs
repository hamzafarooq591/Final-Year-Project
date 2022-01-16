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

    public class AppointmentTestResultResultService : IAppointmentTestResultService
    {
        public AppointmentTestResultViewModel CreateAppointmentTestResult(AppointmentTestResultBindingModel model, int userId)
        {
           
            foreach (var AppointmentTestResultFile in model.AppointmentTestResultFileList)
            {

                AppointmentTestResult entity = model.ToEntity(userId, null);
                NashWebApi.NashContext context = new NashWebApi.NashContext();

                AppointmentTestResultViewModel model2 = new AppointmentTestResultViewModel();
                AppointmentTestResultRepository repository = new AppointmentTestResultRepository(context);

                NashWebApi.NashContext imageUploadContext = new NashContext();
                ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

                ImageUpload imageUploadEntity = new ImageUpload
                {
                    fileUrl = AppointmentTestResultFile,
                    Title = "image_" + model.AppointmentId,
                    Description = "image_Description_" + model.AppointmentId,
                    CreatedByUserId = entity.CreatedByUserId,
                    CreatedOn = entity.CreatedOn,
                    IsDeleted = false,
                    ModifiedByUserId = entity.ModifiedByUserId,
                    ModifiedOn = entity.ModifiedOn
                };

                
                using (UnitOfWork work = new UnitOfWork(imageUploadContext))
                {
                    imageUploadEntity = imageUploadRepository.Add(imageUploadEntity);
                    work.Complete();
                }

                entity.AppointmentTestResultImageId = imageUploadEntity.Id;

                using (UnitOfWork work = new UnitOfWork(context))
                {

                    entity = repository.Add(entity);
                    work.Complete();


                }


            }

           


           // return repository.FindOneMapped(entity.Id);
            return null;


            

        }

        public bool DeleteAppointmentTestResult(int AppointmentTestResultResultId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentTestResultRepository repository = new AppointmentTestResultRepository(context);
            AppointmentTestResult entity = repository.FindOne(AppointmentTestResultResultId).FirstOrDefault<AppointmentTestResult>();
          
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

        public AppointmentTestResultViewModel GetAppointmentTestResultByAppointmentTestResultId(int AppointmentTestResultId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentTestResultRepository repository = new AppointmentTestResultRepository(context);
            if (repository.FindOne(AppointmentTestResultId).FirstOrDefault<AppointmentTestResult>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmenTestId. AppointmenTest Not Found.");
            }
            var result = repository.FindOneMapped(AppointmentTestResultId);

            
            var appointmentTestResultList = repository.FindAllByAppointmentId(result.AppointmentId).ToList();

            var appointmentTestResultFileList = new List<string>();

            foreach (var appointmentTestResultFile in appointmentTestResultList)
            {
                appointmentTestResultFileList.Add(appointmentTestResultFile.AppointmentTestResultImage.fileUrl);
            }

            result.AppointmentTestResultFileList = appointmentTestResultFileList;

            return result;
        }

        public List<string> GetAppointmentTestResultByAppointmentId(int AppointmentId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentTestResultRepository repository = new AppointmentTestResultRepository(context);
            
            var appointmentTestResultList = repository.FindAllByAppointmentId(AppointmentId).ToList();

            var appointmentTestResultFileList = new List<string>();

            foreach (var appointmentTestResultFile in appointmentTestResultList)
            {
                appointmentTestResultFileList.Add(appointmentTestResultFile.AppointmentTestResultImage.fileUrl);
            }

            return appointmentTestResultFileList;

        }

        public NashPagedList<AppointmentTestResultViewModel> GetAppointmentTestResult(int rows, int pageNumber, int? BranchId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AppointmentTestResultRepository repository = new AppointmentTestResultRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber).ToViewModel();

            return result;
        }

        public AppointmentTestResultViewModel UpdateAppointmentTestResult(AppointmentTestResultBindingModel model, int userId)
        {

            NashWebApi.NashContext appointmentTestResultDeletecontext = new NashWebApi.NashContext();
            AppointmentTestResultRepository appointmentTestResulDeleteRepository = new AppointmentTestResultRepository(appointmentTestResultDeletecontext);
            if (appointmentTestResulDeleteRepository.FindOne(model.AppointmentTestResultId.Value)
                .FirstOrDefault<AppointmentTestResult>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AppointmenTestResultId. AppointmenResultTest Not Found.");
            }
            
            var result = appointmentTestResulDeleteRepository.FindOneMapped(model.AppointmentTestResultId.Value);


            var appointmentTestResultList = appointmentTestResulDeleteRepository
                .FindAllByAppointmentId(result.AppointmentId).ToList();

            // Delete all images of result

            foreach (var appointmentTestResult in appointmentTestResultList)
            {
                NashWebApi.NashContext imageUploadContext = new NashWebApi.NashContext();
                ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

                using (UnitOfWork work = new UnitOfWork(imageUploadContext))
                {
                    imageUploadRepository.Delete(appointmentTestResult.AppointmentTestResultImage);
                    work.Complete();
                }
            }

            // Delete all result

            foreach (var appointmentTestResult in appointmentTestResultList)
            {
                NashWebApi.NashContext appointmentTestResultcontext = new NashWebApi.NashContext();
                AppointmentTestResultRepository appointmentTestResulRepository = new AppointmentTestResultRepository(appointmentTestResultcontext);

                using (UnitOfWork work = new UnitOfWork(appointmentTestResultcontext))
                {
                    appointmentTestResulRepository.Delete(appointmentTestResult);
                    work.Complete();
                }
            }




            foreach (var AppointmentTestResultFile in model.AppointmentTestResultFileList)
            {

               
                NashWebApi.NashContext context = new NashWebApi.NashContext();

                AppointmentTestResultViewModel model2 = new AppointmentTestResultViewModel();
                AppointmentTestResultRepository repository = new AppointmentTestResultRepository(context);

                int? AppointmenTestResultId = model.AppointmentTestResultId;
                AppointmentTestResult original = repository.FindOne(AppointmenTestResultId.HasValue ? AppointmenTestResultId.GetValueOrDefault() : 0).FirstOrDefault<AppointmentTestResult>();
                if (original == null)
                {
                    throw new NashHandledExceptionNotFound("Invalid AppointmenTestId. AppointmenTest Not Found.");
                }
                AppointmentTestResult entity = model.ToEntity(userId, original);


                NashWebApi.NashContext imageUploadContext = new NashContext();
                ImageUploadRepository imageUploadRepository = new ImageUploadRepository(imageUploadContext);

                ImageUpload imageUploadEntity = new ImageUpload
                {
                    fileUrl = AppointmentTestResultFile,
                    Title = "image_" + model.AppointmentId,
                    Description = "image_Description_" + model.AppointmentId,
                    CreatedByUserId = entity.CreatedByUserId,
                    CreatedOn = entity.CreatedOn,
                    IsDeleted = false,
                    ModifiedByUserId = entity.ModifiedByUserId,
                    ModifiedOn = entity.ModifiedOn
                };


                using (UnitOfWork work = new UnitOfWork(imageUploadContext))
                {
                    imageUploadEntity = imageUploadRepository.Add(imageUploadEntity);
                    work.Complete();
                }

                entity.AppointmentTestResultImageId = imageUploadEntity.Id;

                using (UnitOfWork work = new UnitOfWork(context))
                {
                    repository.Add(entity);
                    work.Complete();
                }


            }

            return this.GetAppointmentTestResultByAppointmentTestResultId(model.AppointmentTestResultId.Value);
        }

       

        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

