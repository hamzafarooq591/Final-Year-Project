namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class InventoryStockBindingModel
    {
        public int? InventoryStockId { get; set; }

        public int ProductId { get; set; }

        public int Available { get; set; }/////on purchase goes up on sale gets down}/////

        public int Returned { get; set; }

        public int Missing { get; set; }

        public int Defected { get; set; }

    }
}

