namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;
    
    public class PurchaseDelivery : AuditField
    {

        public DateTime PurchaseDeliveryDate { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }
        public int PurchaseOrderId { get; set; }

        [ForeignKey("SaleDeliveryId")]
        public SaleDelivery SaleDelivery { get; set; }
        public int SaleDeliveryId { get; set; }
        
        public decimal PurchaseBookingRateMund { get; set; }
        
        public decimal TotalAmount { get; set; }




    }
}