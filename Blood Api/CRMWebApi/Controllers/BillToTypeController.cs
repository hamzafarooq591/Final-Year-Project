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

    [RoutePrefix("api/BillToType")]
    public class BillToTypeController : ApiController
    {
        private BillToTypeService _BillToTypeService = new BillToTypeService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{BillToTypeId}")]
        public DataActionResponse DeleteBillToType(int BillToTypeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._BillToTypeService.DeleteBillToType(BillToTypeId).CreateDataActionResponseSuccessForDelete("BillToTypeId", BillToTypeId);
        }

        //get
        [HttpGet, Route("{BillToTypeId}")]
        public DataActionResponse Get(int BillToTypeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BillToTypeService.GetBillToTypeByBillToTypeId(BillToTypeId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<BillToTypeViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BillToTypeService.GetBillToType(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(BillToTypeBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _BillToTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._BillToTypeService.CreateBillToType(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{BillToTypeId}")]
        public DataActionResponse Put(BillToTypeBindingModel model, int BillToTypeId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _BillToTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._BillToTypeService.UpdateBillToType(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

