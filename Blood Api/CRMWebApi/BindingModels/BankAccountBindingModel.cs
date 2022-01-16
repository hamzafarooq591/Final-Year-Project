namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class BankAccountBindingModel
    {
        public int? BankAccountId { get; set; }

        public string AccountTitle { get; set; }

        public string AccountNumber { get; set; }

        public string BranchCode { get; set; }

        public float OpeningBalance { get; set; }

        public int CompanyId { get; set; }

        public int BankId { get; set; }
    }
}

