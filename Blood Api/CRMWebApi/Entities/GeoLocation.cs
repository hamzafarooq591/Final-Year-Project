namespace NashWebApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class GeoLocation : AuditField
    {
        public ICollection<City> Cities { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string Currency { get; set; }

        public string CurrencyCode { get; set; }
    }
}

