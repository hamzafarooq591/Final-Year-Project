 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CompanySettingViewModel : IAuditFieldViewModel
    {
        public int CompanySettingId { get; set; }

        public decimal MundRateInKG { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

