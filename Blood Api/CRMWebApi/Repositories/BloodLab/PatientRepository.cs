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
    
    public class PatientRepository : Repository<Patient>, IPatientRepository, IRepository<Patient>
    {
        public PatientRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Patient> Filter(int rows, int pageNumber)
        {
            var result = NashContext.Patients
               .Where(x =>  x.IsDeleted == false );
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Patient>(pageNumber, rows);
        }
        //ParentPatientId List
        
        public PatientViewModel FindOneMapped(int PatientId) =>
            this.FindOne(PatientId).FirstOrDefault<Patient>().ToViewModel();

        public IQueryable<Patient> FindOne(int PatientId)
        {
            return NashContext.Patients
                .Where(x => x.Id == PatientId && x.IsDeleted == false);
        }

        public IQueryable<Patient> GetAll(int PatientId)
        {
            return NashContext.Patients;
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

