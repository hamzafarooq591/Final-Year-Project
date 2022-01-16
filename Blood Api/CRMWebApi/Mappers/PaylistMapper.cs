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

    public static class PayslipMapper
    {
        public static Payslip ToEntity(this PayslipBindingModel model, int userId, Payslip original = null)
        {
            bool flag = original != null;
            Payslip company = flag ? model.Map<PayslipBindingModel, Payslip>(original) : model.Map<PayslipBindingModel, Payslip>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Payslip>(userId);
            }
            return company.MapLastModifiedFields<Payslip>(userId);
        }
        public static NashPagedList<PayslipViewModel> ToViewModel(this IPagedList<Payslip> models)
        {
            List<PayslipViewModel> viewModels = new List<PayslipViewModel>();
            models.ToList<Payslip>().ForEach(delegate (Payslip a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PayslipViewModel>(models.GetMetaData());
        }
        public static PayslipViewModel ToViewModel(this Payslip model)
        {
            return model.Map<Payslip, PayslipViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Payslip, PayslipViewModel>()
                .ForMember(x => x.EmployeeId, y => y.MapFrom(x => x.Employee.Id))
                .ForMember(x => x.PayslipId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.EmployeeFullName, y => y.MapFrom(x => x.Employee.GetFullName()))
                .ForMember(x => x.ApprovalId, y => y.MapFrom(x => x.Approval.Id))
                .ForMember(x => x.ApprovalTitle, y => y.MapFrom(x => x.Approval.ApprovalTitle))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Employee.Branch.BranchName))
                .ForMember(x => x.EmployeeDesignation, y => y.MapFrom(x => x.Employee.Designation.DesignationName));
            }).MapAuditableFields<PayslipViewModel>(model);

        }
    }
}

