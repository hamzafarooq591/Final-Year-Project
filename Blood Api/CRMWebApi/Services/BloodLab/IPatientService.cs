namespace NashWebApi.Services.BloodLab
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;

    public interface IPatientService
    {
        PatientViewModel CreatePatient(PatientBindingModel model, int userId);
        bool DeletePatient(int PatientId);
        PatientViewModel GetPatientByPatientId(int PatientId);
        NashPagedList<PatientViewModel> GetPatient(int rows, int pageNumber , int? BranchId = null);
        PatientViewModel UpdatePatient(PatientBindingModel model, int userId);
        bool ActivatePatient(bool isActive, int PatientId);


    }
}

