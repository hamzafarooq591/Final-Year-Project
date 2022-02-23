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

    public class PatientService : IPatientService
    {
        public PatientViewModel CreatePatient(PatientBindingModel model, int userId)
        {
            Patient entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            PatientViewModel model2 = new PatientViewModel();
            PatientRepository repository = new PatientRepository(context);
            Patient patient = repository.GetAll().
                FirstOrDefault(x => x.FullName==entity.FullName && x.PhoneNumber==entity.PhoneNumber);
           
            using (UnitOfWork work = new UnitOfWork(context))
            {
                if (patient != null)
                {
                    return model2;
                    
                }
                else
                {
                    entity = repository.Add(entity);
                    work.Complete();
                    return repository.FindOneMapped(entity.Id);
                }
            }
        }

        public bool DeletePatient(int PatientId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PatientRepository repository = new PatientRepository(context);
            Patient entity = repository.FindOne(PatientId).FirstOrDefault<Patient>();
          
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PatientId. Patient Not Found.");
            }
          
           else 
            {
                entity.IsDeleted = true;
                using (UnitOfWork work = new UnitOfWork(context))
                {
                    repository.Edit(entity);
                    work.Complete();
                }
                return true;
            }
            //else
             //throw new NashException("Head Patient can't be deleted.");
        }

        public PatientViewModel Authenticate(string PatientPhoneNumber, string Password)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PatientRepository repository = new PatientRepository(context);

            //var patient = repository.GetAll()
            //    .FirstOrDefault<Patient>(x => x.PhoneNumber == PatientPhoneNumber
            //    && x.Password == Password && x.IsActive == true
            //    && x.IsVerified == true && x.IsDeleted == false);
            var patient = context.Patients.Where(w => w.PhoneNumber == PatientPhoneNumber && w.Password == Password && w.IsVerified == true && w.IsDeleted == false).FirstOrDefault();
            if (patient == null)
            {
                return null;
            }
            else
            {
                return repository.FindOneMapped(patient.Id);
            }
        }
        public PatientViewModel GetPatientByPatientId(int PatientId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PatientRepository repository = new PatientRepository(context);
            if (repository.FindOne(PatientId).FirstOrDefault<Patient>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PatientId. Patient Not Found.");
            }
            var result = repository.FindOneMapped(PatientId);

            return result;
        }

        public NashPagedList<PatientViewModel> GetPatient(int rows, int pageNumber, int? BranchId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PatientRepository repository = new PatientRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber).ToViewModel();

            return result;
        }

        public bool ActivatePatient(bool isActive,int PatientId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PatientRepository repository = new PatientRepository(context);
            Patient entity = repository.FindOne(PatientId).FirstOrDefault<Patient>();

            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PatientId. Patient Not Found.");
            }

            // if (entity.PatientHeadId != null)
            // {
            entity.IsActive = isActive;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
            //}
            //else
            //  throw new NashException("Head Patient can't be deleted.");
        }
        public PatientViewModel UpdatePatient(PatientBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PatientRepository repository = new PatientRepository(context);
            int? PatientId = model.PatientId;
            Patient original = repository.FindOne(PatientId.HasValue ? PatientId.GetValueOrDefault() : 0).FirstOrDefault<Patient>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PatientId. Patient Not Found.");
            }
            Patient entity = model.ToEntity(userId, original);
            
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetPatientByPatientId(entity.Id);
        }

        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

