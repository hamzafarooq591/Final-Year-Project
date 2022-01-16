namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmployeeLoanBindingModel
    {
        public int? EmployeeLoanId { get; set; }

        public float LoanAmount { get; set; }

        public int ApprovalId { get; set; }

        public int EmployeeId { get; set; }

    }
}

