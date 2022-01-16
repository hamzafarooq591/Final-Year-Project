namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;
    
    public class SaleDelivery : AuditField
    {

        public DateTime SaleDeliveryDate { get; set; }

        [ForeignKey("SellOrderId")]
        public SellOrder SellOrder { get; set; }
        public int SellOrderId { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }
        public int PurchaseOrderId { get; set; }
        

        public decimal InsuranceCharges { get; set; }

        public decimal TransportCharges { get; set; }

        [ForeignKey("TransporterId")]
        public Customer Transporter { get; set; }
        public int? TransporterId { get; set; }

        public string VehicleNumber { get; set; }

        public bool isXMILL { get; set; }

        public decimal TotalAmount { get; set; }


    }
}