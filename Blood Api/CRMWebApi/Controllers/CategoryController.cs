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

    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private CategoryService _CategoryService = new CategoryService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{CategoryId}")]
        public DataActionResponse DeleteCategory(int CategoryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CategoryService.DeleteCategory(CategoryId).CreateDataActionResponseSuccessForDelete("CategoryId", CategoryId);
        }

        //get
        [HttpGet, Route("{CategoryId}")]
        public DataActionResponse Get(int CategoryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CategoryService.GetCategoryByCategoryId(CategoryId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<CategoryViewModel> Get(int size = 10, int page = 1,string SearchString ="")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CategoryService.GetCategory(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(CategoryBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _CategoryService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._CategoryService.CreateCategory(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{CategoryId}")]
        public DataActionResponse Put(CategoryBindingModel model, int CategoryId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _CategoryService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._CategoryService.UpdateCategory(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

