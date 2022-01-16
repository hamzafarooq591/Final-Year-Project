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

    [RoutePrefix("api/B2BTransfer")]
    public class B2BTransferController : ApiController
    {
        private B2BTransferService _B2BTransferService = new B2BTransferService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{B2BTransferId}")]
        public DataActionResponse DeleteB2BTransfer(int B2BTransferId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._B2BTransferService.DeleteB2BTransfer(B2BTransferId).CreateDataActionResponseSuccessForDelete("B2BTransferId", B2BTransferId);
        }

        //get
        [HttpGet, Route("{B2BTransferId}")]
        public DataActionResponse Get(int B2BTransferId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._B2BTransferService.GetB2BTransferByB2BTransferId(B2BTransferId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<B2BTransferViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._B2BTransferService.GetB2BTransfer(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(B2BTransferBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _B2BTransferService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._B2BTransferService.CreateB2BTransfer(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{B2BTransferId}")]
        public DataActionResponse Put(B2BTransferBindingModel model, int B2BTransferId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _B2BTransferService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._B2BTransferService.UpdateB2BTransfer(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

