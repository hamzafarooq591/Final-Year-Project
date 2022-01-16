 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class AccountViewModel : IAuditFieldViewModel
    {
        public string AccountDescription { get; set; }
        public int AccountId { get; set; }
        public int ParentAccountId { get; set; }
        public string ParentAccountName { get; set; }
        public string AccountName { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

