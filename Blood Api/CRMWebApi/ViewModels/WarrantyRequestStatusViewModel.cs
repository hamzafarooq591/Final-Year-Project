 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WarrantyRequestStatusViewModel : IAuditFieldViewModel
    {
        public string StatusDescription { get; set; }
        public int WarrantyRequestStatusId { get; set; }
        public string StatusTitle { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

