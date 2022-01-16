namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Warranty : AuditField
    {
        [ForeignKey("OrderId")]
        public NashWebApi.Entities.Order Order { get; set; }
        public int OrderId { get; set; }

        public int BranchId { get; set; }

        public int CustomerId { get; set; }

        public string SerialMAC { get; set; }

        public string ReplacementSerialMAC { get; set; }

        [ForeignKey("WarrantyModeId")]
        public NashWebApi.Entities.WarrantyMode WarrantyMode { get; set; }
        public int WarrantyModeId { get; set; }

        public DateTime WarrantyStartDate { get; set; }

        public DateTime WarrantyEndDate { get; set; }
    }
}

