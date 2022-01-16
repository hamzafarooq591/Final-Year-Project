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

    [RoutePrefix("api/Payslip")]
    public class PayslipController : ApiController
    {
        private PayslipService _PayslipService = new PayslipService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{PayslipId}")]
        public DataActionResponse DeletePayslip(int PayslipId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PayslipService.DeletePayslip(PayslipId).CreateDataActionResponseSuccessForDelete("PayslipId", PayslipId);
        }

        //get
        [HttpGet, Route("{PayslipId}")]
        public DataActionResponse Get(int PayslipId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PayslipService.GetPayslipByPayslipId(PayslipId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<PayslipViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PayslipService.GetPayslip(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(PayslipBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PayslipService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PayslipService.CreatePayslip(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{PayslipId}")]
        public DataActionResponse Put(PayslipBindingModel model, int PayslipId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PayslipService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PayslipService.UpdatePayslip(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

