namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class ReturnProduct : AuditField
    {

        public int ReturnQuantity { get; set; }

        public DateTime ReturnProductDate { get; set; }

        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("CustomerId")]
        public NashWebApi.Entities.Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}

