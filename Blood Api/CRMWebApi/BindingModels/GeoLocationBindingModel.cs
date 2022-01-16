namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class GeoLocationBindingModel
    {
        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string Currency { get; set; }

        public string CurrencyCode { get; set; }

        public int? GeoLocationId { get; set; }
    }
}

