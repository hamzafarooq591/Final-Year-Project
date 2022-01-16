namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class InventoryRequest : AuditField
    {
        [ForeignKey("BranchId")]
        public NashWebApi.Entities.Branch Branch { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }

        public DateTime RequestDate { get; set; }

        public int RequestQuantity { get; set; }

        public string Comments { get; set; }

    }
}