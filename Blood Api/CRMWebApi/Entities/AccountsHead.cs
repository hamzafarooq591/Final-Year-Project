namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class AccountsHead : AuditField
    {
        [ForeignKey("AssetId")]
        public Account Asset { get; set; }
        public int AssetId { get; set; }

        [ForeignKey("LiabilityId")]
        public Account Liability { get; set; }
        public int LiabilityId { get; set; }

        [ForeignKey("IncomeOrRevenueId")]
        public Account IncomeOrRevenue { get; set; }
        public int IncomeOrRevenueId { get; set; }

        [ForeignKey("ExpensesId")]
        public Account Expenses { get; set; }
        public int ExpensesId { get; set; }

        [ForeignKey("EquityOrCapitalId")]
        public Account EquityOrCapital { get; set; }
        public int EquityOrCapitalId { get; set; }

    }
}

