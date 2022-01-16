namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class ProductInStore : AuditField
    {
        [ForeignKey("BranchId")]
        public NashWebApi.Entities.Branch Branch { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("PersonId")]
        public NashWebApi.Entities.NashUser NashUser { get; set; }
        public int PersonId { get; set; }

        public int ProductQuantity { get; set; }

    }
}