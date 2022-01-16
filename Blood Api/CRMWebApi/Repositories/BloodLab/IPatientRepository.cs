namespace NashWebApi.Repositories.BloodLab
{
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPatientRepository : IRepository<Patient>
    {
        IPagedList<Patient> Filter(int rows, int pageNumber);
        IQueryable<Patient> FindOne(int PatientId);
        PatientViewModel FindOneMapped(int PatientId);
    }
}

