 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class AccountsHeadViewModel : IAuditFieldViewModel
    {
        public int AccountsHeadId { get; set; }

        public int AssetId { get; set; }

        public int LiabilityId { get; set; }

        public int IncomeOrRevenueId { get; set; }

        public int ExpensesId { get; set; }

        public int EquityOrCapitalId { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

