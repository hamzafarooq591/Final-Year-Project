namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class OfferViewModel : IAuditFieldViewModel
    {
        public int OfferId { get; set; }

        public int BrandOutletId { get; set; }

        public String BrandOutletName { get; set; }

        public bool IsPublished { get; set; }

        public float OfferComission { get; set; }

        public string OfferDescription { get; set; }

        public string OfferTitle { get; set; }

        public string OfferValidation { get; set; }

        public string PublishedFrom { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }

    public class OfferOutletViewModel : IAuditFieldViewModel
    {
        public int BrandOutletId { get; set; }
        public string BrandOutletName { get; set; }
        public int OfferId { get; set; }
        public string OfferTitle { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }


}

