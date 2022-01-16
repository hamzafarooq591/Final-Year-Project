 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class InvoiceSummaryViewModel : IAuditFieldViewModel
    {
        public int InvoiceSummaryId { get; set; }

        public int TotalBilled { get; set; }

        public int TotalPaid { get; set; }

        public int TotalPending { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

