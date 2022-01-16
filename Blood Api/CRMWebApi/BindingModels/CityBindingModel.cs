namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CityBindingModel
    {
        public string CityCode { get; set; }

        public int? CityId { get; set; }

        public string CityName { get; set; }

        public int GeoLocationId { get; set; }

        public string phoneCode { get; set; }
    }
}

