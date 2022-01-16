namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;

    public interface IImageUploadService
    {
        ImageUploadViewModel CreateImageUpload(ImageUploadBindingModel model, int userId);
        bool DeleteImageUpload(int ImageUploadId);
        NashPagedList<ImageUploadViewModel> GetImageUploads(int rows, int pageNumber);
        ImageUploadViewModel GetImageUploadByImageUploadId(int ImageUploadId);
        ImageUploadViewModel UpdateImageUpload(ImageUploadBindingModel model, int userId);
    }
}

