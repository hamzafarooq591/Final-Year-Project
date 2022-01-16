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

    [RoutePrefix("api/ProfitLossReport")]
    public class ProfitLossReportController : ApiController
    {
        private AccountService _ProfitLossReportService = new AccountService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

        //get all
        [HttpGet, Route("")]
        public ProfitLossReportViewModel Get()
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ProfitLossReportService.GetProfitAndLoss();
        }
    }
}