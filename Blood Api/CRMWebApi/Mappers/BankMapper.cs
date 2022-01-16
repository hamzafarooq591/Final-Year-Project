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

    public static class BankMapper
    {
        public static Bank ToEntity(this BankBindingModel model, int userId, Bank original = null)
        {
            bool flag = original != null;
            Bank company = flag ? model.Map<BankBindingModel, Bank>(original) : model.Map<BankBindingModel, Bank>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Bank>(userId);
            }
            return company.MapLastModifiedFields<Bank>(userId);
        }
        public static NashPagedList<BankViewModel> ToViewModel(this IPagedList<Bank> models)
        {
            List<BankViewModel> viewModels = new List<BankViewModel>();
            models.ToList<Bank>().ForEach(delegate (Bank a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<BankViewModel>(models.GetMetaData());
        }
        public static BankViewModel ToViewModel(this Bank model)
        {
            return model.Map<Bank, BankViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Bank, BankViewModel>()
                .ForMember(x => x.BankId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<BankViewModel>(model);

        }
    }
}