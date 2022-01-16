 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class SmsConfigurationViewModel : IAuditFieldViewModel
    {
        public int SmsConfigurationId { get; set; }

        public int SmsTypeId { get; set; }
        public string SmsTypeTitle { get; set; }

        public string URL { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string DeviceName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

