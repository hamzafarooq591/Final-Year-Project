namespace NashWebApi.BindingModels
{
    using NashWebApi.Entities;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class SaleDeliveryItemBindingModel
    {
        public int? SaleDeliveryItemId { get; set; }

        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemWeightKG { get; set; }
        public int Quantity { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Total { get; set; }

        public int SaleDeliveryId { get; set; }

    }
}

