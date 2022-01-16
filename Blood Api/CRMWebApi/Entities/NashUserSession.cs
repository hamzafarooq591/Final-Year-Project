namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class NashUserSession : AuditField
    {

        public int NashUserId { get; set; }
        [ForeignKey("NashUserId")]
        public NashUser NashUser { get; set; }
        
        public bool IsExpired { get; set; }

        public int SessionDuration { get; set; }

        public string SessionKey { get; set; }

        public DateTime? SessionStart { get; set; }

        public DateTime? SessionEnd { get; set; }
    }
}

