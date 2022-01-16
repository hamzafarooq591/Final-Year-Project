 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class TransactionInquiryViewModel : IAuditFieldViewModel
    {
        public int TransactionId { get; set; }

        public string TransactionDate { get; set; }

        public string Description { get; set; }

        public float Debit { get; set; }

        public float Credit { get; set; }

        public float Balance { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public int AccountId { get; set; }
        public string AccountName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

