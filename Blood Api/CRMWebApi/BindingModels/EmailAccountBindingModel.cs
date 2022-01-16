namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmailAccountBindingModel
    {
        public int? EmailAccountId { get; set; }

        public string SenderEmailAddress { get; set; }

        public string SenderName { get; set; }

        public string HostAddress { get; set; }

        public string HostPortNumber { get; set; }

        public string HostUserName { get; set; }

        public string HostPassword { get; set; }

        public bool IsSSL { get; set; }
    }
}

