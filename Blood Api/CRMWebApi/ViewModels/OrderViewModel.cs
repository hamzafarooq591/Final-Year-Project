 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class OrderViewModel : IAuditFieldViewModel
    {
        public int OrderId { get; set; }

        public string OrderPlacementDate { get; set; }

        public int OrderQuantity { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int OrderStatusId { get; set; }
        public string OrderStatusTitle { get; set; }

        public int NashUserId { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int InvoiceId { get; set; }
        public string InvoiceCode { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

