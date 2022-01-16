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

    [RoutePrefix("api/Manufacturer")]
    public class ManufacturerController : ApiController
    {
       // private ManufacturerService _anufacturerService = new CompanyService();
        private ManufacturerService _ManufacturerService = new ManufacturerService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;
//delete
        [HttpPost, Route("Delete/{ManufacturerId}")]
        public DataActionResponse DeleteManufacturer(int manufacturerId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ManufacturerService.DeleteManufacturer(manufacturerId).CreateDataActionResponseSuccessForDelete("manufacturerId", manufacturerId);
        }

        //get
        [HttpGet, Route("{manufacturerId}")]
        public DataActionResponse Get(int manufacturerId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ManufacturerService.GetManufacturerByManufacturerId(manufacturerId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<ManufacturerViewModel> Get(int size = 10, int page = 1,string SearchString ="")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ManufacturerService.GetManufacturer(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(ManufacturerBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ManufacturerService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ManufacturerService.CreateManufacturer(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{manufacturerId}")]
        public DataActionResponse Put(ManufacturerBindingModel model, int manufacturerId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ManufacturerService.UpdateManufacturer(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

