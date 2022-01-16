namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class MissingItemBindingModel
    {
        public int? MissingItemId { get; set; }

        public int BranchId { get; set; }

        public int ProductId { get; set; }

        public string ItemDate { get; set; }

        public int ItemQuantity { get; set; }

        public string Comments { get; set; }
    }
}