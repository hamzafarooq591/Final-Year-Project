namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class EmployeeLoan : AuditField
    {
        public float LoanAmount { get; set; }

        [ForeignKey("ApprovalId")]
        public NashWebApi.Entities.Approval Approval { get; set; }
        public int ApprovalId{ get; set; }

        [ForeignKey("EmployeeId")]
        public NashWebApi.Entities.Employee Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}

