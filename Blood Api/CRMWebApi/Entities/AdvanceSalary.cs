namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class AdvanceSalary : AuditField
    {
        public DateTime AdvanceSalaryDate { get; set; }
        public float AdvanceAmount { get; set; }
        public string Comments { get; set; }

        [ForeignKey("BankAccountId")]
        public NashWebApi.Entities.BankAccount BankAccount { get; set; }
        public int BankAccountId { get; set; }

        [ForeignKey("PaymentTypeId")]
        public NashWebApi.Entities.PaymentType PaymentType { get; set; }
        public int PaymentTypeId { get; set; }

        [ForeignKey("EmployeeId")]
        public NashWebApi.Entities.Employee Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}
