 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class AdvanceSalaryViewModel : IAuditFieldViewModel
    {
        public int AdvanceSalaryId { get; set; }
        public DateTime AdvanceSalaryDate { get; set; }
        public float AdvanceAmount { get; set; }
        public string Comments { get; set; }

        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeTitle { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

