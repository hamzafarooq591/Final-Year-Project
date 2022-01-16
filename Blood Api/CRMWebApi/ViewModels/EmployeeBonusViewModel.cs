namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmployeeBonusViewModel : IAuditFieldViewModel
    {

        public int EmployeeBonusId { get; set; }

        public DateTime BonusMonth { get; set; }

        public string BonusOccasion { get; set; }

        public float BonusAmount { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

