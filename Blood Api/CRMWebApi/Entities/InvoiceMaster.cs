namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class InvoiceMaster : AuditField
    {
        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public float TotalAmount { get; set; }

        public float SaleTax { get; set; }

        public float GrandTotal { get; set; }

        public string PayOrderNumber { get; set; }

       [ForeignKey("BillToTypeId")]//for selection to type (Company, ClearingAgent, etc import section)
        public NashWebApi.Entities.BillToType BillToType { get; set; }
        public int BillToTypeId { get; set; }

        [ForeignKey("CompanyId")]
        public NashWebApi.Entities.NashCompany Company { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey("ImageUploadId")]//for uploading Image Proof
        public NashWebApi.Entities.ImageUpload ImageUpload { get; set; }
        public int? ImageUploadId { get; set; }

        public int BillToId { get; set; }//for BillToType Selected id e.g Clearing Agent ID

        public string Comments { get; set; }
        //Performa Invoice Fields
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