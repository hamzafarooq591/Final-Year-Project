namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class BrandBindingModel
    {

        public int? BrandId { get; set; }

        public string BrandName { get; set; }

        public string BrandImage { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public int CategoryId { get; set; }

        public int? IsFeatured { get; set; }

    }

    public class BrandCatalogueBindingModel
    {
        public int? BrandCatalogueId { get; set; }

        public int BrandId { get; set; }

        public int? CatalogueId { get; set; }

        public string CatalogueImageUrl { get; set; }

        public int CatalogueImageId { get; set; }
    }

    public class BrandFacilityBindingModel
    {
        public int? BrandFacilityId { get; set; }

        public int BrandId { get; set; }

        public int? FacilityId { get; set; }
        
        public int OutletId { get; set; }
    }

    public class BrandOutletBindingModel
    {
        public int? BrandOutletId { get; set; }

        public int BrandId { get; set; }

        public string Address { get; set; }
        
        public int CityId { get; set; }

        public string ContactImageUrl { get; set; }

        public string BrandOutletName { get; set; }

        public string BrandOutletImageUpload { get; set; }

        public string latitute { get; set; }

        public string longitude { get; set; }

        public string password { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Zipcode { get; set; }

        public string BrandOutletOfferReedemPin { get; set; }

    }

    public class BrandPhotoBindingModel
    {
        public int? BrandPhotoId { get; set; }

        public int BrandId { get; set; }

        public string PhotoUrl { get; set; }

        public int? PhotoId { get; set; }
    }
}

