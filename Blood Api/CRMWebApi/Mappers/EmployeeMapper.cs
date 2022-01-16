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

    public static class EmployeeMapper
    {
        public static Employee ToEntity(this EmployeeBindingModel model, int userId, Employee original = null)
        {
            bool flag = original != null;
            Employee company = flag ? model.Map<EmployeeBindingModel, Employee>(original) : model.Map<EmployeeBindingModel, Employee>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Employee>(userId);
            }
            return company.MapLastModifiedFields<Employee>(userId);
        }
        public static NashPagedList<EmployeeViewModel> ToViewModel(this IPagedList<Employee> models)
        {
            List<EmployeeViewModel> viewModels = new List<EmployeeViewModel>();
            models.ToList<Employee>().ForEach(delegate (Employee a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<EmployeeViewModel>(models.GetMetaData());
        }
        public static EmployeeViewModel ToViewModel(this Employee model)
        {
            return model.Map<Employee, EmployeeViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Employee, EmployeeViewModel>()
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Branch.BranchName))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.DesignationName, y => y.MapFrom(x => x.Designation.DesignationName))
                .ForMember(x => x.EmployeeFullName, y => y.MapFrom(x => x.GetFullName()));
                ;
            }).MapAuditableFields<EmployeeViewModel>(model);
        }
    }
}

