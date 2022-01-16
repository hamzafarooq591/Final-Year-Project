 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class InvoiceDetailViewModel : IAuditFieldViewModel
    {
        public int InvoiceDetailId { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Total { get; set; }
        
        public int InvoiceMasterId { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

