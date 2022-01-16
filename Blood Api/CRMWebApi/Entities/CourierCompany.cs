namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class CourierCompany : AuditField
    {
        public string CourierCompanyName { get; set; }

        public string CourierCompanyNumber { get; set; }

    }
}