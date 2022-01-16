namespace NashWebApi.BindingModels
{
    using NashWebApi.Entities;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class PurchaseDeliveryBindingModel
    {
        public int? PurchaseDeliveryId { get; set; }

        public DateTime PurchaseDeliveryDate { get; set; }
        
        public int PurchaseOrderId { get; set; }
        
        public int SaleDeliveryId { get; set; }

        public decimal PurchaseBookingRateMund { get; set; }

        public decimal TotalAmount { get; set; }

        public List<PurchaseDeliveryItemBindingModel> PurchaseDeliveryItems { get; set; }
    }
}

