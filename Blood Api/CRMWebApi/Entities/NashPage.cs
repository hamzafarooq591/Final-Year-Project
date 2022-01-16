namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class NashPage : AuditField
    {
        public string Description { get; set; }

        [ForeignKey("ParentPageId")]
        public NashPage ParentPage { get; set; }

        public int? ParentPageId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}

