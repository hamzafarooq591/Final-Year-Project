namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ProductBindingModel
    {
        public string ProductShortDescription { get; set; }
        public string ProductLongDescription { get; set; }
        public string ProductName { get; set; }
        public int? ProductId { get; set; }
        public string OldPrice { get; set; }
        public string SpecialPrice { get; set; }
        public DateTime SpecialPriceStartDate { get; set; }
        public DateTime SpecialPriceEndDate { get; set; }
        public int WarrantyModeId { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public bool IsShowOnHomePage { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsFeaturedProduct { get; set; }
        public bool AllowCustomerReviews { get; set; }
        public bool DisableBuyButton { get; set; }
        public bool MacAddressRequired { get; set; }

    }
}

