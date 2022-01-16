namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class SmsConfiguration : AuditField
    {
        [ForeignKey("SmsTypeId")]
        public NashWebApi.Entities.SmsType SmsType { get; set; }
        public int SmsTypeId { get; set; }

        public string URL { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string DeviceName { get; set; }

    }
}