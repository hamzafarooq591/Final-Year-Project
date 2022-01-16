namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class BankAccount : AuditField
    {

        public string AccountTitle { get; set; }

        public string AccountNumber { get; set; }

        public string BranchCode { get; set; }

        public float OpeningBalance { get; set; }

        [ForeignKey("CompanyId")]
        public NashWebApi.Entities.NashCompany Company{ get; set; }
        public int CompanyId { get; set; }

        [ForeignKey("BankId")]
        public NashWebApi.Entities.Bank Bank { get; set; }
        public int BankId { get; set; }

    }
}