namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class InvoiceMasterBindingModel
    {
        public int? InvoiceMasterId { get; set; }

        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public float TotalAmount { get; set; }

        public float SaleTax { get; set; }

        public float GrandTotal { get; set; }

        public string PayOrderNumber { get; set; }

        public int CompanyId { get; set; }
        public int? ImageUploadId { get; set; }
        public string ImageUploadfileUrl { get; set; }

        public string Comments { get; set; }

        public int BillToId { get; set; }

        public int BillToTypeId { get; set; }
    }
}

