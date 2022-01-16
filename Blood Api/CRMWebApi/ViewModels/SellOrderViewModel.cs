 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class SellOrderViewModel : IAuditFieldViewModel
    {
        public int? SellOrderId { get; set; }

        public DateTime sellDate { get; set; }

        public string ItemName { get; set; }
        public int ItemId { get; set; }
        
        public int PartyId { get; set; }
        public string PartyName { get; set; }

        public int PurchaseOrderId { get; set; }

        public decimal Rate { get; set; }

        public decimal QuantityinWeight { get; set; }
        public decimal ReminingWeight { get; set; }
        public decimal Quantity { get; set; }
        public bool isCompleted { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

