namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class OrderBindingModel
    {
        public int? OrderId { get; set; }

        public DateTime OrderPlacementDate { get; set; }

        public int OrderQuantity { get; set; }

        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? NashUserId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? InvoiceId { get; set; }
    }
}

