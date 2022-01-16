namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Account : AuditField
    {
        public string AccountDescription { get; set; }
        public string AccountName { get; set; }

        [ForeignKey("ParentAccountId")]
        public Account ParentAccount { get; set; }
        public int? ParentAccountId { get; set; }

        public int? AccountHeadId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public int BranchId { get; set; }
    }
}

