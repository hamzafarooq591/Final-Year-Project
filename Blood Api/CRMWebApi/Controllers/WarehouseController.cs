﻿namespace NashWebApi.Controllers
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

    [RoutePrefix("api/Warehouse")]
    public class WarehouseController : ApiController
    {
        private WarehouseService _WarehouseService = new WarehouseService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{WarehouseId}")]
        public DataActionResponse DeleteWarehouse(int WarehouseId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarehouseService.DeleteWarehouse(WarehouseId).CreateDataActionResponseSuccessForDelete("WarehouseId", WarehouseId);
        }

        //get
        [HttpGet, Route("{WarehouseId}")]
        public DataActionResponse Get(int WarehouseId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarehouseService.GetWarehouseByWarehouseId(WarehouseId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<WarehouseViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarehouseService.GetWarehouse(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(WarehouseBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarehouseService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarehouseService.CreateWarehouse(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{WarehouseId}")]
        public DataActionResponse Put(WarehouseBindingModel model, int WarehouseId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarehouseService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarehouseService.UpdateWarehouse(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

