 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class B2BTransferViewModel : IAuditFieldViewModel
    {
        public int B2BTransferId { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int FromBankAccountId { get; set; }
        public string FromBankAccountName { get; set; }
        public int ToBankAccountId { get; set; }
        public string ToBankAccountName { get; set; }

        public float Amount { get; set; }

        public float BankCharges { get; set; }

        public string TransferDate { get; set; }

        public string TransferDescription { get; set; }

        public string UploadProof { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

