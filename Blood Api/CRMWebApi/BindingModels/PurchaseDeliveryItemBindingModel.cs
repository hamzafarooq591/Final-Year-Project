namespace NashWebApi.BindingModels
{
    using NashWebApi.Entities;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class PurchaseDeliveryItemBindingModel
    {
        public int? PurchaseDeliveryItemId { get; set; }

        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        
        public int PurchaseDeliveryId { get; set; }

    }
}

