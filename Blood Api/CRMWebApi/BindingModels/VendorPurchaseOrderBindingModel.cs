namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class VendorPurchaseOrderBindingModel
    {

        public int? VendorPurchaseOrderId { get; set; }

        public int CompanyId { get; set; }

        public int VendorId { get; set; }

        public string PayOrderDate { get; set; }

        public string PONumber { get; set; }//Auto 

        public string SupplierInvoiceNo { get; set; }

        public float ExchangeRate { get; set; }

        public int ImageUploadId { get; set; }
        public string PurchaseImageUrl { get; set; }

        public string comments { get; set; }

    }
}

