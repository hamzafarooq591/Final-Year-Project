namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class PaymentDetail : AuditField
    {

        [ForeignKey("CustomerId")]
        public NashWebApi.Entities.Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("BankAccountId")]
        public NashWebApi.Entities.BankAccount BankAccount { get; set; }
        public int BankAccountId { get; set; }

        [ForeignKey("PaymentTypeId")]
        public NashWebApi.Entities.PaymentType PaymentType { get; set; }
        public int PaymentTypeId { get; set; }

        [ForeignKey("PayToTypeId")]//Payment (from ro to) Customer//2 radio buttons
        public NashWebApi.Entities.PayToType PayToType { get; set; }
        public int PayToTypeId { get; set; }

        public float Amount { get; set; }

        public string CheqOrRefNo { get; set; }

        public DateTime ClearingDate { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public bool SendSMS { get; set; }

        [ForeignKey("PaymentStatusId")]
        public NashWebApi.Entities.Approval PaymentStatus { get; set; }
        public int PaymentStatusId { get; set; }

        [ForeignKey("ImageProofId")]
        public NashWebApi.Entities.ImageUpload ImageProof { get; set; }
        public int ImageProofId { get; set; }

    }
}
