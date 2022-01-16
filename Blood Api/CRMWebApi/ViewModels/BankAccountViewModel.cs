 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class BankAccountViewModel : IAuditFieldViewModel
    {
        public int BankAccountId { get; set; }

        public string AccountTitle { get; set; }

        public string AccountNumber { get; set; }

        public string BranchCode { get; set; }

        public float OpeningBalance { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int BankId { get; set; }
        public string BankName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

        //public int ParentCategoryId { get; set; }
        //public string ParentCategoryName { get; set; }

    }
}

