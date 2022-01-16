namespace NashWebApi.Mappers
{
    using AutoMapper;
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class EmployeeLoanMapper
    {
        public static EmployeeLoan ToEntity(this EmployeeLoanBindingModel model, int userId, EmployeeLoan original = null)
        {
            bool flag = original != null;
            EmployeeLoan company = flag ? model.Map<EmployeeLoanBindingModel, EmployeeLoan>(original) : model.Map<EmployeeLoanBindingModel, EmployeeLoan>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<EmployeeLoan>(userId);
            }
            return company.MapLastModifiedFields<EmployeeLoan>(userId);
        }
        public static NashPagedList<EmployeeLoanViewModel> ToViewModel(this IPagedList<EmployeeLoan> models)
        {
            List<EmployeeLoanViewModel> viewModels = new List<EmployeeLoanViewModel>();
            models.ToList<EmployeeLoan>().ForEach(delegate (EmployeeLoan a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<EmployeeLoanViewModel>(models.GetMetaData());
        }
        public static EmployeeLoanViewModel ToViewModel(this EmployeeLoan model)
        {
            return model.Map<EmployeeLoan, EmployeeLoanViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<EmployeeLoan, EmployeeLoanViewModel>()
                .ForMember(x => x.EmployeeLoanId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.EmployeeName, y => y.MapFrom(x => x.Employee.GetFullName()))
                .ForMember(x => x.ApprovalTitle, y => y.MapFrom(x => x.Approval.ApprovalTitle));
                ;
            }).MapAuditableFields<EmployeeLoanViewModel>(model);

        }
    }
}

