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

    public static class AppointmentTestResultMapper
    {
        public static AppointmentTestResult ToEntity(this AppointmentTestResultBindingModel model, int userId, AppointmentTestResult original = null)
        {
            bool flag = original != null;
            AppointmentTestResult company = flag ? model.Map<AppointmentTestResultBindingModel, AppointmentTestResult>(original) : model.Map<AppointmentTestResultBindingModel, AppointmentTestResult>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<AppointmentTestResult>(userId);
            }
            return company.MapLastModifiedFields<AppointmentTestResult>(userId);
        }
        public static NashPagedList<AppointmentTestResultViewModel> ToViewModel(this IPagedList<AppointmentTestResult> models)
        {
            List<AppointmentTestResultViewModel> viewModels = new List<AppointmentTestResultViewModel>();
            models.ToList<AppointmentTestResult>().ForEach(delegate (AppointmentTestResult a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<AppointmentTestResultViewModel>(models.GetMetaData());
        }
        public static AppointmentTestResultViewModel ToViewModel(this AppointmentTestResult model)
        {
            return model.Map<AppointmentTestResult, AppointmentTestResultViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<AppointmentTestResult, AppointmentTestResultViewModel>()
                .ForMember(x => x.AppointmentTestResultId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<AppointmentTestResultViewModel>(model);

        }


       
    }
}

