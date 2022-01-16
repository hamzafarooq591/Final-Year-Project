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

    [RoutePrefix("api/Branch")]
    public class BranchController : ApiController
    {
        private BranchService _BranchService = new BranchService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{BranchId}")]
        public DataActionResponse DeleteBranch(int BranchId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BranchService.DeleteBranch(BranchId).CreateDataActionResponseSuccessForDelete("BranchId", BranchId);
        }

        //get
        [HttpGet, Route("{BranchId}")]
        public DataActionResponse Get(int BranchId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BranchService.GetBranchByBranchId(BranchId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<BranchViewModel> Get(int size = 10, int page = 1,int? CompanyId=null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BranchService.GetBranch(size, page, CompanyId);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(BranchBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _BranchService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._BranchService.CreateBranch(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{BranchId}")]
        public DataActionResponse Put(BranchBindingModel model, int BranchId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _BranchService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._BranchService.UpdateBranch(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

