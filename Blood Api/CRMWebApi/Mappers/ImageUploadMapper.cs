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

    public static class ImageUploadMapper
    {
        public static ImageUpload ToEntity(this ImageUploadBindingModel model, int userId, ImageUpload original = null)
        {
            bool flag = original != null;
            ImageUpload ImageUpload = flag ? model.Map<ImageUploadBindingModel, ImageUpload>(original) : model.Map<ImageUploadBindingModel, ImageUpload>();
            if (!flag)
            {
                return ImageUpload.MapCreatedAndLastModifiedFields<ImageUpload>(userId);
            }
            return ImageUpload.MapLastModifiedFields<ImageUpload>(userId);
        }

        public static ImageUploadViewModel ToViewModel(this ImageUpload model)
        {
           return model.Map<ImageUpload, ImageUploadViewModel>(delegate (IMapperConfigurationExpression cfg) {

               cfg.CreateMap<ImageUpload, ImageUploadViewModel>()
              .ForMember(x => x.ImageUploadId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<ImageUploadViewModel>(model);
        }
        public static NashPagedList<ImageUploadViewModel> ToViewModel(this IPagedList<ImageUpload> models)
        {
            List<ImageUploadViewModel> viewModels = new List<ImageUploadViewModel>();
            models.ToList<ImageUpload>().ForEach(delegate (ImageUpload a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ImageUploadViewModel>(models.GetMetaData());
        }

        public static IList<ImageUploadViewModel> ToViewModel(this IList<ImageUpload> models)
        {
            List<ImageUploadViewModel> viewModels = new List<ImageUploadViewModel>();
            models.ToList<ImageUpload>().ForEach(delegate (ImageUpload a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

       
    }
}

