namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Employee : AuditField
    {
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public int BranchId { get; set; }

        public string EmployeeFName { get; set; }

        public string EmployeeLName { get; set; }

        [ForeignKey("DesignationId")]
        public Designation Designation { get; set; }
        public int DesignationId { get; set; }

        public string EmployeeCode { get; set; }

        public DateTime? EmployeeJoiningDate { get; set; }

        public float EmployeeBasicSalary { get; set; }

        public float EmployeeConveyanceAllowance { get; set; }

        public float EmployeeHouseRent { get; set; }

        public float EmployeeMedicalAllowance { get; set; }

        public float EmployeeEducationAllowance { get; set; }

        public float EmployeeMobileAllowance { get; set; }

        public string BankName { get; set; }

        public string AccountNumber { get; set; }

        public string MobileNumber { get; set; }

    }
}

