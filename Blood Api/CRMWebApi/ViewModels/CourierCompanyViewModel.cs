 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CourierCompanyViewModel : IAuditFieldViewModel
    {
        public int CourierCompanyId { get; set; }

        public string CourierCompanyName { get; set; }

        public string CourierCompanyNumber { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

