namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PurchaseOrderBindingModel
    {

        public int PurchaseOrderId { get; set; }
        public DateTime Date { get; set; }
        public int ItemId { get; set; }
        public int PartyId { get; set; }
        public decimal Rate { get; set; }
        public decimal RateInKG { get; set; }
        public decimal QuantityinWeight { get; set; }
        public bool isCompleted { get; set; }
    }
}

