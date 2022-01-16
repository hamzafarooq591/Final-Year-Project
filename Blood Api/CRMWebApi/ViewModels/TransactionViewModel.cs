 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class TransactionViewModel : IAuditFieldViewModel
    {
        public string TransactionDescription { get; set; }
        public int TransactionId { get; set; }
        public bool TransactionType { get; set; }

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public float Amount { get; set; }
        public float Balance { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }

    public class LedgerViewModel : IAuditFieldViewModel
    {
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        public float Credit { get; set; }
        public float Debit { get; set; }
        public float Balance { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
    
}

