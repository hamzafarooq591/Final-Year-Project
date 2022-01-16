namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class VendorPurchaseOrder : AuditField
    {
        [ForeignKey("CompanyId")]
        public NashWebApi.Entities.NashCompany Company { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey("VendorId")]
        public NashWebApi.Entities.Vendor Vendor { get; set; }
        public int VendorId { get; set; }

        public DateTime PayOrderDate { get; set; }

        public string PONumber { get; set; }

        public string SupplierInvoiceNo { get; set; }

        public float ExchangeRate {get; set; }

        [ForeignKey("ImageUploadId")]
        public NashWebApi.Entities.ImageUpload InvoiceImage { get; set; }
        public int ImageUploadId { get; set; }

        public string comments { get; set; }
        
    }
}