namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmployeeLoanViewModel : IAuditFieldViewModel
    {

        public int EmployeeLoanId { get; set; }

        public float LoanAmount { get; set; }

        public int ApprovalId { get; set; }
        public string ApprovalTitle { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

