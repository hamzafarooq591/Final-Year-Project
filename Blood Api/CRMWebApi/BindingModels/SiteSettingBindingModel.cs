namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class SiteSettingBindingModel
    {
        public int? SiteSettingId { get; set; }

        public string PageTitleSeparator { get; set; }

        public string DefaultTitle { get; set; }

        public string DefaultMetaKeyword { get; set; }

        public string DefaultMetaDescription { get; set; }

    }
}

