namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.Services.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    [RoutePrefix("api/Offer")]
    public class OfferController : ApiController
    {
        private OfferService _OfferService = new OfferService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{OfferId}")]
        public DataActionResponse DeleteOffer(int OfferId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._OfferService.DeleteOffer(OfferId).CreateDataActionResponseSuccessForDelete("OfferId", OfferId);
        }
       
        //get
        [HttpGet, Route("{OfferId}")]
        public DataActionResponse Get(int OfferId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._OfferService.GetOfferByOfferId(OfferId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<OfferViewModel> Get(int size = 10, int page = 1,int? BranchId=null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OfferService.GetOffer(size, page, BranchId);
        }
       
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(OfferBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OfferService.CreateOffer(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{OfferId}")]
        public DataActionResponse Put(OfferBindingModel model, int OfferId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OfferService.UpdateOffer(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

