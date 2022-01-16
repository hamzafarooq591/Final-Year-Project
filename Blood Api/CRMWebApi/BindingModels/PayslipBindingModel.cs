namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PayslipBindingModel
    {
        public int? PayslipId { get; set; }

        public string PayMonth { get; set; }

        public int EmployeeId { get; set; }

        public int ApprovalId { get; set; }

        public float PaidAmount { get; set; }

        public DateTime? PayDate { get; set; }

        public float EmployeeBonusAmount { get; set; }

        public float AdvanceSalaryAmount { get; set; }

        public float EmployeeLoanAmount { get; set; }

        public float EmployeeBasicSalary { get; set; }

        public float EmployeeTotalAllownces { get; set; }

        public float AbsentAmount { get; set; }

        public float OtherDeductionAmount { get; set; }
    }
}

