 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class BankViewModel : IAuditFieldViewModel
    {
        public int BankId { get; set; }

        public string BankName { get; set; }

        public string BankAddress { get; set; }

        public string BankPhoneNo { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

