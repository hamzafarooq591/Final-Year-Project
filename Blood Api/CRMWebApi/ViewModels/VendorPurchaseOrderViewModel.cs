 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class VendorPurchaseOrderViewModel : IAuditFieldViewModel
    {
        public int VendorPurchaseOrderId { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int VendorId { get; set; }
        public string VendorName { get; set; }

        public string PayOrderDate { get; set; }

        public string PONumber { get; set; }

        public string SupplierInvoiceNo { get; set; }

        public float ExchangeRate { get; set; }

        public int ImageUploadId { get; set; }
        //public string PurchaseImageUrl { get; set; }

        public string comments { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

