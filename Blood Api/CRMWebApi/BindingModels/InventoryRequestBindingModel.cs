namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class InventoryRequestBindingModel
    {
        public int? InventoryRequestId { get; set; }

        public int BranchId { get; set; }

        public int ProductId { get; set; }

        public string RequestDate { get; set; }

        public int RequestQuantity { get; set; }

        public string Comments { get; set; }

    }
}