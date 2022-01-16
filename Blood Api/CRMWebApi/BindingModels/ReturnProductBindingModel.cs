namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ReturnProductBindingModel
    {
        public int? ReturnProductId { get; set; }

        public int ReturnQuantity { get; set; }

        public string ReturnProductDate { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

    }
}

