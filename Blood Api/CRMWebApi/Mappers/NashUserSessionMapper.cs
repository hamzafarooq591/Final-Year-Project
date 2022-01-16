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

    public static class NashUserSessionMapper
    {
        public static NashUserSession ToEntity(this NashUserSessionBindingModel model, int userId, NashUserSession original = null)
        {
            bool flag = original != null;
            NashUserSession NashUserSession = flag ? model.Map<NashUserSessionBindingModel, NashUserSession>(original) : model.Map<NashUserSessionBindingModel, NashUserSession>();
            if (!flag)
            {
                return NashUserSession.MapCreatedAndLastModifiedFields<NashUserSession>(userId);
            }
            return NashUserSession.MapLastModifiedFields<NashUserSession>(userId);
        }

        public static NashUserSessionViewModel ToViewModel(this NashUserSession model)
        {
           return model.Map<NashUserSession, NashUserSessionViewModel>(delegate (IMapperConfigurationExpression cfg) {

               cfg.CreateMap<NashUserSession, NashUserSessionViewModel>()
              .ForMember(x => x.NashUserSessionId, y => y.MapFrom(x => x.Id));
              
            }).MapAuditableFields<NashUserSessionViewModel>(model);
        }
        public static NashPagedList<NashUserSessionViewModel> ToViewModel(this IPagedList<NashUserSession> models)
        {
            List<NashUserSessionViewModel> viewModels = new List<NashUserSessionViewModel>();
            models.ToList<NashUserSession>().ForEach(delegate (NashUserSession a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NashUserSessionViewModel>(models.GetMetaData());
        }

        public static IList<NashUserSessionViewModel> ToViewModel(this IList<NashUserSession> models)
        {
            List<NashUserSessionViewModel> viewModels = new List<NashUserSessionViewModel>();
            models.ToList<NashUserSession>().ForEach(delegate (NashUserSession a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

       
    }
}

