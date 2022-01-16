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

    public static class OfferMapper
    {
        public static Offer ToEntity(this OfferBindingModel model, int userId, Offer original = null)
        {
            bool flag = original != null;
            Offer company = flag ? model.Map<OfferBindingModel, Offer>(original) : model.Map<OfferBindingModel, Offer>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Offer>(userId);
            }
            return company.MapLastModifiedFields<Offer>(userId);
        }
        public static NashPagedList<OfferViewModel> ToViewModel(this IPagedList<Offer> models)
        {
            List<OfferViewModel> viewModels = new List<OfferViewModel>();
            models.ToList<Offer>().ForEach(delegate (Offer a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<OfferViewModel>(models.GetMetaData());
        }
        public static OfferViewModel ToViewModel(this Offer model)
        {
            return model.Map<Offer, OfferViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Offer, OfferViewModel>()
                .ForMember(x => x.OfferId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<OfferViewModel>(model);

        }


       
    }
}

