namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class GeoLocationViewModel : IAuditFieldViewModel
    {
        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string CreatedBy { get; set; }

        public string Currency { get; set; }

        public string CurrencyCode { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public int? GeoLocationId { get; set; }

        public string LastModified { get; set; }
    }
}

