namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class InvoiceDetail : AuditField
    {
        public string Model { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Total { get; set; }

        [ForeignKey("InvoiceMasterId")]
        public NashWebApi.Entities.InvoiceMaster InvoiceMaster { get; set; }
        public int InvoiceMasterId { get; set; }
    }
}