 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class OtherPaymentViewModel : IAuditFieldViewModel
    {
        public int OtherPaymentId { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeTitle { get; set; }

        public int StatusId { get; set; }
        public int StatusTitle { get; set; }

        public string Type { get; set; }//Payment Type(Salary/Loan/Advance/Bonus etc)

        public string ClearingDate { get; set; }

        public string Date { get; set; }

        public string CheqOrRefNo { get; set; }

        public float Amount { get; set; }

        public string Comments { get; set; }

        public int ImageProofId { get; set; }
        public string ImageProofURL { get; set; }
        public string ImageProofTitle { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

