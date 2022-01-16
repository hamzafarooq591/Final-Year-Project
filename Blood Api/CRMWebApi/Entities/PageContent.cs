namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class PageContent : AuditField
    {
        [ForeignKey("StaticPageId")]
        public NashWebApi.Entities.StaticPage StaticPage { get; set; }
        public int StaticPageId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsIncludedSiteMap { get; set; }

    }
}