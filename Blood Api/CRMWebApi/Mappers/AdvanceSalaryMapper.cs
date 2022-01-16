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

    public static class AdvanceSalaryMapper
    {
        public static AdvanceSalary ToEntity(this AdvanceSalaryBindingModel model, int userId, AdvanceSalary original = null)
        {
            bool flag = original != null;
            AdvanceSalary company = flag ? model.Map<AdvanceSalaryBindingModel, AdvanceSalary>(original) : model.Map<AdvanceSalaryBindingModel, AdvanceSalary>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<AdvanceSalary>(userId);
            }
            return company.MapLastModifiedFields<AdvanceSalary>(userId);
        }
        public static NashPagedList<AdvanceSalaryViewModel> ToViewModel(this IPagedList<AdvanceSalary> models)
        {
            List<AdvanceSalaryViewModel> viewModels = new List<AdvanceSalaryViewModel>();
            models.ToList<AdvanceSalary>().ForEach(delegate (AdvanceSalary a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<AdvanceSalaryViewModel>(models.GetMetaData());
        }
        public static AdvanceSalaryViewModel ToViewModel(this AdvanceSalary model)
        {
            return model.Map<AdvanceSalary, AdvanceSalaryViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<AdvanceSalary, AdvanceSalaryViewModel>()
                .ForMember(x => x.EmployeeFullName, y => y.MapFrom(x => x.Employee.GetFullName()))
                .ForMember(x => x.AdvanceSalaryId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.PaymentTypeTitle, y => y.MapFrom(x => x.PaymentType.Title))
                .ForMember(x => x.BankAccountName, y => y.MapFrom(x => x.BankAccount.AccountTitle));
            }).MapAuditableFields<AdvanceSalaryViewModel>(model);

        }
    }
}

