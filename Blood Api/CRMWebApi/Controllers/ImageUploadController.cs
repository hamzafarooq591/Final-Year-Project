namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.ViewModels;
    using System;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    [RoutePrefix("api/ImageUpload")]
    public class ImageUploadController : ApiController
    {
        private ImageUploadService _ImageUploadService = new ImageUploadService();
        private NashUserService _NashUserService = new NashUserService();

        private int UserId = 1;

        [HttpPost, Route("Delete/{ImageUploadId}")]
        public DataActionResponse DeleteImageUpload(int ImageUploadId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._ImageUploadService.DeleteImageUpload(ImageUploadId).CreateDataActionResponseSuccessForDelete("ImageUploadId", ImageUploadId);
        }

        [HttpGet, Route("{ImageUploadId}")]
        public DataActionResponse Get(int ImageUploadId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._ImageUploadService.GetImageUploadByImageUploadId(ImageUploadId).CreateDataActionResponseSuccess();
        }

        [HttpGet, Route("")]
        public NashPagedList<ImageUploadViewModel> Get(int size = 0x3e8, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._ImageUploadService.GetImageUploads(size, page);
        }

        [HttpPost, Route("")]
        public DataActionResponse Post(ImageUploadBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._ImageUploadService.CreateImageUpload(model, this.UserId).CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("Put/{ImageUploadId}")]
        public DataActionResponse Put(ImageUploadBindingModel model, int ImageUploadId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._ImageUploadService.UpdateImageUpload(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

