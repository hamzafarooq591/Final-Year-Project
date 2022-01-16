namespace NashWebApi.Mappers.BloodLab
{
    using AutoMapper;
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class PatientMapper
    {
        public static Patient ToEntity(this PatientBindingModel model, int userId, Patient original = null)
        {
            bool flag = original != null;
            Patient company = flag ? model.Map<PatientBindingModel, Patient>(original) : model.Map<PatientBindingModel, Patient>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Patient>(userId);
            }
            return company.MapLastModifiedFields<Patient>(userId);
        }
        public static NashPagedList<PatientViewModel> ToViewModel(this IPagedList<Patient> models)
        {
            List<PatientViewModel> viewModels = new List<PatientViewModel>();
            models.ToList<Patient>().ForEach(delegate (Patient a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PatientViewModel>(models.GetMetaData());
        }
        public static PatientViewModel ToViewModel(this Patient model)
        {
            return model.Map<Patient, PatientViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Patient, PatientViewModel>()
                .ForMember(x => x.PatientId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<PatientViewModel>(model);

        }


       
    }
}

