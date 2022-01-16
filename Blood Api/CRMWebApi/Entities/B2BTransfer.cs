namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class B2BTransfer : AuditField
    {
        [ForeignKey("BranchId")]
        public NashWebApi.Entities.Branch Branch { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("FromBankAccountId")]
        public NashWebApi.Entities.BankAccount FromBankAccount { get; set; }
        public int FromBankAccountId { get; set; }

        [ForeignKey("ToBankAccountId")]
        public NashWebApi.Entities.BankAccount ToBankAccount { get; set; }
        public int ToBankAccountId { get; set; }

        public float Amount { get; set; }

        public float BankCharges { get; set; }

        public DateTime TransferDate { get; set; }

        public string TransferDescription { get; set; }

        public string UploadProof { get; set; }

    }
}
