namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Web.Http;
    
    [RoutePrefix("api/Transaction")]
    public class TransactionController : ApiController
    {
        private TransactionService _TransactionService = new TransactionService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{TransactionId}")]
        public DataActionResponse DeleteTransaction(int TransactionId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._TransactionService.DeleteTransaction(TransactionId).CreateDataActionResponseSuccessForDelete("TransactionId", TransactionId);
        }

        //get
        [HttpGet, Route("{TransactionId}")]
        public DataActionResponse Get(int TransactionId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._TransactionService.GetTransactionByTransactionId(TransactionId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<TransactionInquiryViewModel> Get(int size = 10, int page = 1, int? AccountId = null,
            DateTime? FromDate = null, DateTime? ToDate = null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._TransactionService.GetTransaction(size, page, AccountId, FromDate, ToDate);
        }

        [HttpGet, Route("Ledger")]
        public NashPagedList<LedgerViewModel> GetAccountLedger(int accountId,int size = 10, int page = 1)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._TransactionService.GetTransactionByAccountId(size, page, accountId);
        }



        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(TransactionBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _TransactionService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._TransactionService.CreateTransaction(model, this.UserId).CreateDataActionResponseSuccess();
        }
        //save Transation List
        [HttpPost, Route("ListSave")]
        public DataActionResponse PostList(List<TransactionBindingModel> models)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _TransactionService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._TransactionService.CreateTransactionList(models, this.UserId).CreateDataActionResponseSuccess();
        }
        //Update
        [HttpPost, Route("Put/{TransactionId}")]
        public DataActionResponse Put(TransactionBindingModel model, int TransactionId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _TransactionService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._TransactionService.UpdateTransaction(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

