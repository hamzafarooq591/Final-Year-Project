namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class WPQuantity : AuditField
    {
        [ForeignKey("WarehouseId")]
        public NashWebApi.Entities.Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }

        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

    }
}