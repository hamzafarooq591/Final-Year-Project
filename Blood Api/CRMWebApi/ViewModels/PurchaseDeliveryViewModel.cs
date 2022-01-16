 namespace NashWebApi.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class PurchaseDeliveryViewModel : IAuditFieldViewModel
    {
        public int PurchaseDeliveryId { get; set; }

        public DateTime PurchaseDeliveryDate { get; set; }

        public string PurchaseOrderName { get; set; }
        public int PurchaseOrderId { get; set; }
        
        public string SaleDeliveryName { get; set; }
        public int SaleDeliveryId { get; set; }

        public decimal PurchaseBookingRateMund { get; set; }

        public decimal TotalAmount { get; set; }

        public List<PurchaseDeliveryItemViewModel> purchaseDeliveryItems { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

