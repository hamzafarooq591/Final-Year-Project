namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmployeeBonusBindingModel
    {
        public int? EmployeeBonusId { get; set; }

        public DateTime BonusMonth { get; set; }

        public string BonusOccasion { get; set; }

        public float BonusAmount { get; set; }
        
        public int EmployeeId { get; set; }

    }
}

