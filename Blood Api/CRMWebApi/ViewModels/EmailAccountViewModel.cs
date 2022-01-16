 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmailAccountViewModel : IAuditFieldViewModel
    {
        public int EmailAccountId { get; set; }

        public string SenderEmailAddress { get; set; }

        public string SenderName { get; set; }

        public string HostAddress { get; set; }

        public string HostPortNumber { get; set; }

        public string HostUserName { get; set; }

        public string HostPassword { get; set; }

        public bool IsSSL { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

