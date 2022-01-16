namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class ProductWarranty : AuditField
    {
        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("WarrantyModeId")]
        public NashWebApi.Entities.WarrantyMode WarrantyMode { get; set; }
        public int WarrantyModeId { get; set; }

        public string SerialMAC { get; set; }

    }
}

