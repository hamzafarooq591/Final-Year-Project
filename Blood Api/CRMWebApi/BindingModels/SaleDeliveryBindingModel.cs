namespace NashWebApi.BindingModels
{
    using NashWebApi.Entities;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class SaleDeliveryBindingModel
    {
        public int? SaleDeliveryId { get; set; }

        public DateTime SaleDeliveryDate { get; set; }
        
        public int SellOrderId { get; set; }
        
        public int PurchaseOrderId { get; set; }
        
        public decimal InsuranceCharges { get; set; }

        public decimal TransportCharges { get; set; }
        
        public int? TransporterId { get; set; }

        public string VehicleNumber { get; set; }

        public bool isXMILL { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal SaleOrderRemainingQuantity { get; set; }

        public decimal PurchaseOrderRemainingQuantity { get; set; }

        public List<SaleDeliveryItemBindingModel> saleDeliveryItems { get; set; }
    }
}

