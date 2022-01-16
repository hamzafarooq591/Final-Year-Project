namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class DcSummary : AuditField
    {
        [ForeignKey("BranchId")]
        public NashWebApi.Entities.Branch Branch { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("GroupId")]
        public NashWebApi.Entities.DcGroup DcGroup { get; set; }
        public int GroupId { get; set; }

        public DateTime DcSummaryDate { get; set; }

        public int Transfered { get; set; }

        public int Received { get; set; }

    }
}