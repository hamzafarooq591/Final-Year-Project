namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class OtherPaymentBindingModel
    {
        public int? OtherPaymentId { get; set; }

        public int BranchId { get; set; }
        public int CompanyId { get; set; }

        public int BankAccountId { get; set; }

        public int PaymentTypeId { get; set; }

        public int StatusId { get; set; }

        public string Type { get; set; }//Payment Type(Salary/Loan/Advance/Bonus etc)

        public string ClearingDate { get; set; }

        public string Date { get; set; }

        public string CheqOrRefNo { get; set; }

        public float Amount { get; set; }

        public string Comments { get; set; }

        public int ImageProofId { get; set; }
        public string ImageProofURL { get; set; }
    }
}

