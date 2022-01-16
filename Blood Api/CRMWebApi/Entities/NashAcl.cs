namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class NashAcl : AuditField
    {
        public bool IsAddAllowed { get; set; }

        public bool IsDeleteAllowed { get; set; }

        public bool IsEditAllowed { get; set; }

        public bool isViewAllowed { get; set; }

        [ForeignKey("PageId")]
        public NashPage Page { get; set; }

        public int PageId { get; set; }

        [ForeignKey("RoleId")]
        public NashRole Role { get; set; }

        public int RoleId { get; set; }
    }
}

