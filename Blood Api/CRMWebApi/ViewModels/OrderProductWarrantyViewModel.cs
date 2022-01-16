 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class OrderProductWarrantyViewModel : IAuditFieldViewModel
    {
        public int OrderProductWarrantyId { get; set; }

        public int OrderId { get; set; }
        public string InvoiceNo { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string MacAddress { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

