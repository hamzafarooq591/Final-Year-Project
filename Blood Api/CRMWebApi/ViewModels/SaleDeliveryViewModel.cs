 namespace NashWebApi.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class SaleDeliveryViewModel : IAuditFieldViewModel
    {
        public int SaleDeliveryId { get; set; }

        public DateTime SaleDeliveryDate { get; set; }
        public string SellOrderName { get; set; }
        public int SellOrderId { get; set; }
        public string PurchaseOrderName { get; set; }
        public int PurchaseOrderId { get; set; }
        public decimal InsuranceCharges { get; set; }
        public decimal TransportCharges { get; set; }
        public string TransporterName { get; set; }
        public int TransporterId { get; set; }
        public string VehicleNumber { get; set; }
        public bool isXMILL { get; set; }
        public decimal TotalAmount { get; set; }

        public decimal SaleOrderRemainingQuantity { get; set; }
        public decimal PurchaseOrderRemainingQuantity { get; set; }

        public List<SaleDeliveryItemViewModel> saleDeliveryItems { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

