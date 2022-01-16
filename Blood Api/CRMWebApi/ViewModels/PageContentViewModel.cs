 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PageContentViewModel : IAuditFieldViewModel
    {
        public int PageContentId { get; set; }

        public int StaticPageId { get; set; }
        public string StaticPageName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsIncludedSiteMap { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

