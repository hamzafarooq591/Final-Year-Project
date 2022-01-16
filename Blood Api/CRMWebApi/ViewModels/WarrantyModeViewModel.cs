 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WarrantyModeViewModel : IAuditFieldViewModel
    {
        public int WarrantyModeId { get; set; }

        public string WarrantyModePeriod { get; set; }

        public int WarrantyModePeriodInDays { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

