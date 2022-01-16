 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class InvoiceMasterViewModel : IAuditFieldViewModel
    {
        public int InvoiceMasterId { get; set; }

        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public float TotalAmount { get; set; }

        public float SaleTax { get; set; }

        public float GrandTotal { get; set; }

        public string PayOrderNumber { get; set; }

        public int BillToTypeId { get; set; }
        public string BillToTypeName { get; set; }

        public int ImageUploadId { get; set; }
        public string ImageUploadURL { get; set; }

        public string Comments { get; set; }

        public int BillToId { get; set; }
        public string BillToName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

        public int CompanyId { get; set; } 
        public string CompanyName { get; set; }

        public string InvoiceTitle { get; set; }

        public string Subject { get; set; }

        public string Para01 { get; set; }

        public string Para02 { get; set; }

        public string EquipmentWarranty { get; set; }

        public string Validity { get; set; }

        public string Taxes { get; set; }

    }
}

