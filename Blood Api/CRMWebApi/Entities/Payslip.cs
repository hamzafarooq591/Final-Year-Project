namespace NashWebApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Payslip : AuditField
    {
        public string PayMonth { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }

        [ForeignKey("ApprovalId")]
        public Approval Approval { get; set; }
        public int? ApprovalId { get; set; }

        public float PaidAmount { get; set; }

        public DateTime? PayDate { get; set; }

        public float EmployeeBonusAmount { get; set; }

        public float EmployeeBasicSalary { get; set; }

        public float EmployeeTotalAllownces { get; set; }

        public float AdvanceSalaryAmount { get; set; }

        public float EmployeeLoanAmount { get; set; }

        public float AbsentAmount { get; set; }

        public float OtherDeductionAmount { get; set; }

    }
}

