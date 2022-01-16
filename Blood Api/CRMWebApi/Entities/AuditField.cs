namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public abstract class AuditField : BaseEntity, IAuditField
    {
        protected AuditField()
        {
        }

        [ScaffoldColumn(false)]
        public int? CreatedByUserId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [ScaffoldColumn(false)]
        public int? ModifiedByUserId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime ModifiedOn { get; set; }
    }
}

