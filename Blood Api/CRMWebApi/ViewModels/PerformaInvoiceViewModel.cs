 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PerformaInvoiceViewModel : IAuditFieldViewModel
    {
        public int PerformaInvoiceId { get; set; }

        public string CompanyNameTitle { get; set; }

        public string InvoiceTitle { get; set; }

        public string Subject { get; set; }

        public string Para01 { get; set; }

        public string Para02 { get; set; }

        public string EquipmentWarranty { get; set; }

        public string Validity { get; set; }

        public string Taxes { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

