namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;
    
    public class PurchaseOrder : AuditField
    {

        public DateTime Date { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        public int ItemId { get; set; }

        [ForeignKey("PartyId")]
        public Customer Party { get; set; }
        public int PartyId { get; set; }
        
        public decimal Rate { get; set; }

        public decimal RateInKG { get; set; }
  
        public decimal QuantityinWeight { get; set; }

        public decimal ReminingWeight { get; set; }

        public bool isCompleted { get; set; }
        

    }
}