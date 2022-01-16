namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class PerformaInvoice : AuditField
    {
        public string CompanyNameTitle { get; set; }

        public string InvoiceTitle { get; set; }

        public string Subject { get; set; }

        public string Para01 { get; set; }

        public string Para02 { get; set; }

        public string EquipmentWarranty { get; set; }

        public string Validity { get; set; }

        public string Taxes { get; set; }

    }
}