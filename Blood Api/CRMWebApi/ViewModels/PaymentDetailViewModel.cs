 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PaymentDetailViewModel : IAuditFieldViewModel
    {
        public int PaymentDetailId { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int PaymentStatusId { get; set; }
        public int PaymentStatusTitle { get; set; }

        public int BankAccountId { get; set; }
        public string BankAccountTitle { get; set; }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeTitle { get; set; }

        public int PayToTypeId { get; set; }
        public string PaytoTypeTitle { get; set; }

        public float Amount { get; set; }

        public string CheqOrRefNo { get; set; }

        public string ClearingDate { get; set; }

        public string Date { get; set; }

        public string Comments { get; set; }

        public bool SendSMS { get; set; }

        public int ImageProofId { get; set; }
        public string ImageProofUrl { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

