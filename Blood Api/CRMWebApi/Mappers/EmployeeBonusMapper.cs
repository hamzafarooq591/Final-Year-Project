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

    public static class EmployeeBonusMapper
    {
        public static EmployeeBonus ToEntity(this EmployeeBonusBindingModel model, int userId, EmployeeBonus original = null)
        {
            bool flag = original != null;
            EmployeeBonus company = flag ? model.Map<EmployeeBonusBindingModel, EmployeeBonus>(original) : model.Map<EmployeeBonusBindingModel, EmployeeBonus>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<EmployeeBonus>(userId);
            }
            return company.MapLastModifiedFields<EmployeeBonus>(userId);
        }
        public static NashPagedList<EmployeeBonusViewModel> ToViewModel(this IPagedList<EmployeeBonus> models)
        {
            List<EmployeeBonusViewModel> viewModels = new List<EmployeeBonusViewModel>();
            models.ToList<EmployeeBonus>().ForEach(delegate (EmployeeBonus a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<EmployeeBonusViewModel>(models.GetMetaData());
        }
        public static EmployeeBonusViewModel ToViewModel(this EmployeeBonus model)
        {
            return model.Map<EmployeeBonus, EmployeeBonusViewModel>(delegate (IMapperConfigurationExpression cfg) {
            cfg.CreateMap<EmployeeBonus, EmployeeBonusViewModel>()
            .ForMember(x => x.EmployeeBonusId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.EmployeeName, y => y.MapFrom(x => x.Employee.GetFullName()));
                ;
            }).MapAuditableFields<EmployeeBonusViewModel>(model);

        }
    }
}

