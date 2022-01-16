 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PurchaseDeliveryItemViewModel : IAuditFieldViewModel
    {
        public int PurchaseDeliveryItemId { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int PurchaseDeliveryId { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

