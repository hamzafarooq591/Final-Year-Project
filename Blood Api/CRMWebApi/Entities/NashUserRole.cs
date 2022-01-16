namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class NashUserRole : AuditField
    {
        [ForeignKey("NashRoleId")]
        public NashWebApi.Entities.NashRole NashRole { get; set; }
        public int NashRoleId { get; set; }

        [ForeignKey("NashUserId")]
        public NashWebApi.Entities.NashUser NashUser { get; set; }
        public int NashUserId { get; set; }
    }
}

