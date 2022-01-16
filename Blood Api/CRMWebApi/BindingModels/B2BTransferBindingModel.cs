namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class B2BTransferBindingModel
    {
        public int? B2BTransferId { get; set; }

        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public int FromBankAccountId { get; set; }
        public int ToBankAccountId { get; set; }

        public float Amount { get; set; }

        public float BankCharges { get; set; }

        public DateTime TransferDate { get; set; }

        public string TransferDescription { get; set; }

        public string UploadProof { get; set; }
    }
}

