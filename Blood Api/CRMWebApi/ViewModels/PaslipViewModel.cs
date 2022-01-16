namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PayslipViewModel : IAuditFieldViewModel
    {

        public int PayslipId { get; set; }

        public string PayMonth { get; set; }

        public string BranchName { get; set; }

        public string EmployeeDesignation { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }        

        public int ApprovalId { get; set; }
        public string ApprovalTitle { get; set; }        

        public float PaidAmount { get; set; }

        public DateTime? PayDate { get; set; }

        public float EmployeeBonusAmount { get; set; }

        public float AdvanceSalaryAmount { get; set; }

        public float EmployeeLoanAmount { get; set; }

        public float AbsentAmount { get; set; }

        public float OtherDeductionAmount { get; set; }

        public float EmployeeBasicSalary { get; set; }

        public float EmployeeTotalAllownces { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

