namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class WarrantyRequestStatus : AuditField
    {
        public string StatusDescription { get; set; }

        public string StatusTitle { get; set; }

    }
}