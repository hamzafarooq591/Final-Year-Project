namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PaymentDetailBindingModel
    {
        public int? PaymentDetailId { get; set; }

        public int CustomerId { get; set; }

        public int PaymentStatusId { get; set; }

        public int BankAccountId { get; set; }

        public int PaymentTypeId { get; set; }

        public int PayToTypeId { get; set; }

        public float Amount { get; set; }

        public string CheqOrRefNo { get; set; }

        public string ClearingDate { get; set; }

        public string Date { get; set; }

        public string Comments { get; set; }

        public bool SendSMS { get; set; }

        public int ImageProofId { get; set; }
        public string ImageProofUrl { get; set; }
    }
}

