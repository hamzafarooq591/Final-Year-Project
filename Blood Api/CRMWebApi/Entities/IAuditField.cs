namespace NashWebApi.Entities
{
    using System;

    public interface IAuditField
    {
        int? CreatedByUserId { get; set; }

        DateTime CreatedOn { get; set; }

        bool IsDeleted { get; set; }

        int? ModifiedByUserId { get; set; }

        DateTime ModifiedOn { get; set; }
    }
}

