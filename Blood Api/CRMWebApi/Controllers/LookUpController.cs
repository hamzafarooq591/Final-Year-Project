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

    [RoutePrefix("api/LookUp")]
    public class LookUpController : ApiController
    {
        private LookUpService _LookUpService = new LookUpService();
        private NashUserService _NashUserService = new NashUserService();
        private ApprovalService _ApprovalService = new ApprovalService();
        private PaymentTypeService _PaymentTypeService = new PaymentTypeService();

        private int UserId = 1;


        #region PaymentType

        //delete
        [HttpPost, Route("PaymentType/Delete/{PaymentTypeId}")]
        public DataActionResponse DeletePaymentType(int PaymentTypeId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PaymentTypeService.DeletePaymentType(PaymentTypeId).CreateDataActionResponseSuccessForDelete("PaymentTypeId", PaymentTypeId);
        }

        //get
        [HttpGet, Route("PaymentType/{PaymentTypeId}")]
        public DataActionResponse GetPaymentType(int PaymentTypeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PaymentTypeService.GetPaymentTypeByPaymentTypeId(PaymentTypeId).CreateDataActionResponseSuccess();
        }
        //getall
        [HttpGet, Route("PaymentType")]
        public NashPagedList<PaymentTypeViewModel> GetAllPaymentType(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PaymentTypeService.GetPaymentType(size, page);
        }
        //save
        [HttpPost, Route("PaymentType")]
        public DataActionResponse Post(PaymentTypeBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PaymentTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PaymentTypeService.CreatePaymentType(model, this.UserId).CreateDataActionResponseSuccess();
        }
        //Update
        [HttpPost, Route("PaymentType/Put/{PaymentTypeId}")]
        public DataActionResponse Put(PaymentTypeBindingModel model, int PaymentTypeId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PaymentTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PaymentTypeService.UpdatePaymentType(model, this.UserId).CreateDataActionResponseSuccess();
        }
        #endregion

        #region Approval

        //delete
        [HttpPost, Route("Approval/Delete/{ApprovalId}")]
        public DataActionResponse DeleteApproval(int ApprovalId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ApprovalService.DeleteApproval(ApprovalId).CreateDataActionResponseSuccessForDelete("ApprovalId", ApprovalId);
        }

        //get
        [HttpGet, Route("Approval/{ApprovalId}")]
        public DataActionResponse GetApproval(int ApprovalId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ApprovalService.GetApprovalByApprovalId(ApprovalId).CreateDataActionResponseSuccess();
        }
        //getall
        [HttpGet, Route("Approval")]
        public NashPagedList<ApprovalViewModel> GetAllApproval(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ApprovalService.GetApproval(size, page);
        }
        //save
        [HttpPost, Route("Approval")]
        public DataActionResponse Post(ApprovalBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ApprovalService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ApprovalService.CreateApproval(model, this.UserId).CreateDataActionResponseSuccess();
        }
        //Update
        [HttpPost, Route("Approval/Put/{ApprovalId}")]
        public DataActionResponse Put(ApprovalBindingModel model, int ApprovalId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ApprovalService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ApprovalService.UpdateApproval(model, this.UserId).CreateDataActionResponseSuccess();
        }
        #endregion

        [HttpPost, Route("City/Delete/{cityId}")]
        public DataActionResponse DeleteCity(int cityId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._LookUpService.DeleteCity(cityId).CreateDataActionResponseSuccessForDelete("CityId", cityId);
        }

       

        [HttpPost, Route("GeoLocation/Delete/{GeoLocationId}")]
        public DataActionResponse DeleteGeoLocation(int GeoLocationId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._LookUpService.DeleteGeoLocation(GeoLocationId).CreateDataActionResponseSuccessForDelete("GeoLocationId", GeoLocationId);
        }

        

        [HttpGet, Route("City")]
        public NashPagedList<CityViewModel> GetCities(int size = 0x3e8, int page = 1, int? GeoLocationId = new int?())
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._LookUpService.GetCities(size, page, GeoLocationId);
        }

        [HttpGet, Route("City/{CityId}")]
        public DataActionResponse GetCity(int CityId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._LookUpService.GetCityByCityId(CityId).CreateDataActionResponseSuccess();
        }

       

        [HttpGet, Route("GeoLocation/{GeoLocationId}")]
        public DataActionResponse GetGeoLocation(int GeoLocationId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._LookUpService.GetGeoLocationByGeoLocationId(GeoLocationId).CreateDataActionResponseSuccess();
        }

        [HttpGet, Route("GeoLocation")]
        public NashPagedList<GeoLocationViewModel> GetGeoLocations(int size = 0x3e8, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._LookUpService.GetGeoLocations(size, page);
        }

        [HttpPost, Route("City")]
        public DataActionResponse Post(CityBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._LookUpService.CreateCity(model, this.UserId).CreateDataActionResponseSuccess();
        }

       

        [HttpPost, Route("GeoLocation")]
        public DataActionResponse Post(GeoLocationBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._LookUpService.CreateGeoLocation(model, this.UserId).CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("City/Put/{cityId}")]
        public DataActionResponse Put(CityBindingModel model, int cityId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._LookUpService.UpdateCity(model, this.UserId).CreateDataActionResponseSuccess();
        }
       
        [HttpPost, Route("GeoLocation/Put/{GeoLocationId}")]
        public DataActionResponse Put(GeoLocationBindingModel model, int GeoLocationId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;
            return this._LookUpService.UpdateGeoLocation(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

