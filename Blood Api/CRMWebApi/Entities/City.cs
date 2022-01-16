namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class City : AuditField
    {
        public string CityCode { get; set; }

        public string CityName { get; set; }

        [ForeignKey("GeoLocationId")]
        public NashWebApi.Entities.GeoLocation GeoLocation { get; set; }

        public int GeoLocationId { get; set; }

        public string phoneCode { get; set; }
    }
}

