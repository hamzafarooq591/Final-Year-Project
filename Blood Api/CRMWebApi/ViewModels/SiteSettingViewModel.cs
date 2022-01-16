 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class SiteSettingViewModel : IAuditFieldViewModel
    {
        public int SiteSettingId { get; set; }

        public string PageTitleSeparator { get; set; }

        public string DefaultTitle { get; set; }

        public string DefaultMetaKeyword { get; set; }

        public string DefaultMetaDescription { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

