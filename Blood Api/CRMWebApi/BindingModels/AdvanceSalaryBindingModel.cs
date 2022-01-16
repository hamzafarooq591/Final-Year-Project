namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class AdvanceSalaryBindingModel
    {
        public int? AdvanceSalaryId { get; set; }
        public DateTime AdvanceSalaryDate { get; set; }
        public float AdvanceAmount { get; set; }
        public string Comments { get; set; }

        public int BankAccountId { get; set; }
        public int PaymentTypeId { get; set; }
        public int EmployeeId { get; set; }
    }
}

