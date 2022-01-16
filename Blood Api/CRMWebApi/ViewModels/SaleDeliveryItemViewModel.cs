 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class SaleDeliveryItemViewModel : IAuditFieldViewModel
    {
        public int SaleDeliveryItemId { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemWeightKG { get; set; }
        public int Quantity { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Total { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

