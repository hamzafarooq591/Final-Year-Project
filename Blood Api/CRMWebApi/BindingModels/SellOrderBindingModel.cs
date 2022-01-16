namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class SellOrderBindingModel
    {

        public int? SellOrderId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public DateTime sellDate { get; set; }
        public int ItemId { get; set; }
        public int PartyId { get; set; }
        public decimal Rate { get; set; }
        public decimal QuantityinWeight { get; set; }
        public decimal Quantity { get; set; }
        public bool isCompleted { get; set; }
    }
}

