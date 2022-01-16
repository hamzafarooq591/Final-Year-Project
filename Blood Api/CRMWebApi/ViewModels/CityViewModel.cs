namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CityViewModel : IAuditFieldViewModel
    {
        public string CityCode { get; set; }

        public int? CityId { get; set; }

        public string CityName { get; set; }

        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public int GeoLocationId { get; set; }

        public string GeoLocationName { get; set; }

        public string LastModified { get; set; }

        public string phoneCode { get; set; }
    }
}

