namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class AccountsHeadBindingModel
    {
        public int? AccountsHeadId { get; set; }

        public int AssetId { get; set; }

        public int LiabilityId { get; set; }

        public int IncomeOrRevenueId { get; set; }

        public int ExpensesId { get; set; }

        public int EquityOrCapitalId { get; set; }

    }
}

