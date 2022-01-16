namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class OtherPayment : AuditField
    {
        public string Type { get; set; }//Payment Type(Salary/Loan/Advance/Bonus etc)

        [ForeignKey("BranchId")]//also for company
        public NashWebApi.Entities.Branch Branch { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("BankAccountId")]
        public NashWebApi.Entities.BankAccount BankAccount { get; set; }
        public int BankAccountId { get; set; }

        [ForeignKey("PaymentTypeId")]
        public NashWebApi.Entities.PaymentType PaymentType { get; set; }
        public int PaymentTypeId { get; set; }

        [ForeignKey("StatusId")]
        public NashWebApi.Entities.Approval Approval { get; set; }
        public int StatusId { get; set; }

        public DateTime ClearingDate { get; set; }

        public DateTime Date { get; set; }
        
        public string CheqOrRefNo { get; set; }

        public float Amount { get; set; }

        public string Comments { get; set; }

        [ForeignKey("ImageProofId")]
        public NashWebApi.Entities.ImageUpload ImageProof { get; set; }
        public int ImageProofId { get; set; }

    }
}
