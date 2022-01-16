namespace NashWebApi.Mappers
{
    using AutoMapper;
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class TestMapper
    {
        public static Test ToEntity(this TestBindingModel model, int userId, Test original = null)
        {
            bool flag = original != null;
            Test company = flag ? model.Map<TestBindingModel, Test>(original) : model.Map<TestBindingModel, Test>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Test>(userId);
            }
            return company.MapLastModifiedFields<Test>(userId);
        }
        public static NashPagedList<TestViewModel> ToViewModel(this IPagedList<Test> models)
        {
            List<TestViewModel> viewModels = new List<TestViewModel>();
            models.ToList<Test>().ForEach(delegate (Test a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<TestViewModel>(models.GetMetaData());
        }
        public static TestViewModel ToViewModel(this Test model)
        {
            return model.Map<Test, TestViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Test, TestViewModel>()
                .ForMember(x => x.TestId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<TestViewModel>(model);

        }


       
    }
}

