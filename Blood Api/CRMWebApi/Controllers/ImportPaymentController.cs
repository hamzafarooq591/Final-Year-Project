namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.ViewModels;
    using System;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    [RoutePrefix("api/ImportPayment")]
    public class ImportPaymentController : ApiController
    {
        private ImportPaymentService _ImportPaymentService = new ImportPaymentService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{ImportPaymentId}")]
        public DataActionResponse DeleteImportPayment(int ImportPaymentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ImportPaymentService.DeleteImportPayment(ImportPaymentId).CreateDataActionResponseSuccessForDelete("ImportPaymentId", ImportPaymentId);
        }

        //get
        [HttpGet, Route("{ImportPaymentId}")]
        public DataActionResponse Get(int ImportPaymentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ImportPaymentService.GetImportPaymentByImportPaymentId(ImportPaymentId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<ImportPaymentViewModel> Get(int size = 10, int page = 1, int? PayToType=0)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ImportPaymentService.GetImportPayment(size, page, PayToType);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(ImportPaymentBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ImportPaymentService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ImportPaymentService.CreateImportPayment(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{ImportPaymentId}")]
        public DataActionResponse Put(ImportPaymentBindingModel model, int ImportPaymentId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ImportPaymentService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ImportPaymentService.UpdateImportPayment(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

