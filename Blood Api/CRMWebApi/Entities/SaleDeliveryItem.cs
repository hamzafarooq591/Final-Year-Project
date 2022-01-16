namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;
    
    public class SaleDeliveryItem : AuditField
    {
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        public int? ItemId { get; set; }

        public string ItemName { get; set; }
        public decimal ItemWeightKG { get; set; }
        public int Quantity { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("SaleDeliveryId")]
        public SaleDelivery SaleDelivery { get; set; }
        public int SaleDeliveryId { get; set; }

    }
}