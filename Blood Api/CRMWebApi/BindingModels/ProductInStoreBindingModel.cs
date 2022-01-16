namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ProductInStoreBindingModel
    {
        public int? ProductInStoreId { get; set; }

        public int BranchId { get; set; }

        public int ProductId { get; set; }

        public int PersonId { get; set; }

        public int ItemQuantity { get; set; }
    }
}