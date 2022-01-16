namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;
    
    public class SellOrder : AuditField
    {

        public DateTime sellDate { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        public int ItemId { get; set; }

        [ForeignKey("PartyId")]
        public Customer Party { get; set; }
        public int PartyId { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }
        public int? PurchaseOrderId { get; set; }

        public decimal Rate { get; set; }

        public decimal QuantityinWeight { get; set; }

        public decimal ReminingWeight { get; set; }

        public decimal Quantity { get; set; }

        public bool isCompleted { get; set; }

    }
}