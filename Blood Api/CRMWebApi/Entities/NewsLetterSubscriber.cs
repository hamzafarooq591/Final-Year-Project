namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class NewsLetterSubscriber : AuditField
    {

        [ForeignKey("NashUserId")]
        public NashWebApi.Entities.NashUser NashUser { get; set; }
        public int NashUserId { get; set; }

        public bool IsActive { get; set; }

    }
}