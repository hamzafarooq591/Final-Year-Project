namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class BrandViewModel : IAuditFieldViewModel
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public string BrandImage { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int CategoryId { get; set; }
        
        public int BrandCategory { get; set; }

        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string LastModified { get; set; }
    }

    public class BrandCatalogueViewModel : IAuditFieldViewModel
    {
        public int BrandCatelogueId { get; set; }

        public int BrandId { get; set; }

        public int CatalogueId { get; set; }

        public string CatalogueImage { get; set; }

        public int CatalogueImageId { get; set; }
        
        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string LastModified { get; set; }
    }

    public class BrandFacilityViewModel : IAuditFieldViewModel
    {
        public int BrandFacilityId { get; set; }

        public int BrandId { get; set; }

        public int FacilityId { get; set; }

        public int OutletId { get; set; }

        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string LastModified { get; set; }
    }

    public class BrandOutletViewModel : IAuditFieldViewModel
    {
        public int BrandOutletId { get; set; }

        public int BrandId { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        public int CountryId { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }

        public string ContactImageUrl { get; set; }


        public string Email { get; set; }

        public string BrandOutletName { get; set; }

        public string latitute { get; set; }

        public string longitude { get; set; }

        public string password { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string WebsiteUrl { get; set; }

        public string Zipcode { get; set; }

        public string BrandOutletOfferReedemPin { get; set; }

        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string LastModified { get; set; }

    }

    public class BrandPhotoViewModel : IAuditFieldViewModel
    {
        public int BrandPhotoId { get; set; }

        public int BrandId { get; set; }

        public string Photo { get; set; }

        public int PhotoId { get; set; }
        
        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string LastModified { get; set; }
    }
}

