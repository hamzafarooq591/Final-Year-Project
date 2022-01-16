namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class OfferBindingModel
    {
        public int? OfferId { get; set; }

        public int BrandOutletId { get; set; }
        
        public bool IsPublished { get; set; }

        public float OfferComission { get; set; }

        public string OfferDescription { get; set; }

        public string OfferTitle { get; set; }

        public string OfferValidation { get; set; }

        public string PublishedFrom { get; set; }
    }
}

