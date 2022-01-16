namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PageContentBindingModel
    {
        public int? PageContentId { get; set; }

        public int StaticPageId { get; set; }
        public string StaticPageName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsIncludedSiteMap { get; set; }
    }
}

