 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class SmsTypeViewModel : IAuditFieldViewModel
    {
        public int SmsTypeId { get; set; }

        public string SmsTypeDescription { get; set; }

        public string SmsTypeTitle { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

