 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CurrencyViewModel : IAuditFieldViewModel
    {
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencyTitle { get; set; }

        public string CurrencySymbol { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

