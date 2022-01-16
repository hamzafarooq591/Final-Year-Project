 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class StaticPageViewModel : IAuditFieldViewModel
    {
        public int StaticPageId { get; set; }

        public string StaticPageDescription { get; set; }

        public string StaticPageName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

