namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class SiteSetting : AuditField
    {

        public string PageTitleSeparator { get; set; }

        public string DefaultTitle { get; set; }

        public string DefaultMetaKeyword { get; set; }

        public string DefaultMetaDescription { get; set; }

    }
}