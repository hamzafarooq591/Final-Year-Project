namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class SmsType : AuditField
    {
        public string SmsTypeDescription { get; set; }

        public string SmsTypeTitle { get; set; }

    }
}