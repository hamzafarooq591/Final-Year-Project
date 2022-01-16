namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class OrderProductWarranty : AuditField
    {

        [ForeignKey("OrderId")]
        public NashWebApi.Entities.Order Order { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string MacAddress { get; set; }

    }
}