namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class InvoiceDetailBindingModel
    {
        public int? InvoiceDetailId { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Total { get; set; }

        public int InvoiceMasterId { get; set; }


    }
}

