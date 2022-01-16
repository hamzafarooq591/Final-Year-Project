namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WPQuantityBindingModel
    {
        public int? WPQuantityId { get; set; }

        public int WarehouseId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

