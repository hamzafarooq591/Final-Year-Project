 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CustomerViewModel : IAuditFieldViewModel
    {
        public int? CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhoneNo { get; set; }

        public string CustomerCompanyName { get; set; }

        public bool isTransporter { get; set; }

        public int AccountId { get; set; }
        public string AccountName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

